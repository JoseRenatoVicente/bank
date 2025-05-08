using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Bank.Domain.Contracts;
using MediatR;

namespace Bank.Domain.Accounts.CalculateIncome
{
  public class CalculateIncomeCommandHandler : IRequestHandler<CalculateIncomeCommand>
  {
    private readonly IAccountRepository _repository;
    private readonly IYieldService _yieldService;

    public CalculateIncomeCommandHandler(IAccountRepository repository, IYieldService yieldService)
    {
      _repository = repository;
      _yieldService = yieldService;
    }
    public Task<Unit> Handle(CalculateIncomeCommand request, CancellationToken cancellationToken)
    {
      var accounts = this._repository.GetAll();

      foreach (var account in accounts)
      {
        var yield = _yieldService.CalculateInterestFor(request.ForDate, account, request.InterestRate, days: 1);
        account.SetYield(yield, request.ForDate);
      }

      _repository.SaveChanges();
      return Unit.Task;
    }
  }
}
