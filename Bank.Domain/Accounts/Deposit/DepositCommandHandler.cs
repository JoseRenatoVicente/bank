using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Bank.Core.Domain.Models;
using Bank.Domain.Contracts;
using Bank.Domain.Entities;
using Bank.Domain.ValueObjects;

using MediatR;

namespace Bank.Domain.Accounts.Deposit
{
  public class DepositCommandHandler : IRequestHandler<DepositCommand, Result<Account>>
  {
    private readonly IAccountRepository _repository;
    private readonly IPaymentService _paymentService;

    public DepositCommandHandler(IAccountRepository repository, IPaymentService paymentService)
    {
      this._repository = repository;
      _paymentService = paymentService;
    }

    public Task<Result<Account>> Handle(DepositCommand request, CancellationToken cancellationToken)
    {
      var account = this._repository.GetById(request.AccountNo);
      if (account is Account)
      {
        var result = account.Deposit(request.Amount);
        return Task.FromResult(Result.From(account, result));

      }
      return Task.FromResult(Result.Fail<Account>($"Conta #{request.AccountNo} não encontrada"));
    }
  }
}
