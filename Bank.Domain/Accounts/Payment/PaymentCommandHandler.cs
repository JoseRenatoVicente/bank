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

namespace Bank.Domain.Accounts.Payment
{
  public class PaymentCommandHandler : IRequestHandler<PaymentCommand, Result<Account>>
  {
    private readonly IAccountRepository _repository;
    private readonly IPaymentService _paymentService;

    public PaymentCommandHandler(IAccountRepository repository, IPaymentService paymentService)
    {
      this._repository = repository;
      _paymentService = paymentService;
    }

    public Task<Result<Account>> Handle(PaymentCommand request, CancellationToken cancellationToken)
    {
      var account = this._repository.GetById(request.AccountNo);
      if (account is IPaybleAccount payable)
      {
        var result = _paymentService.Pay(payable, request.Invoice);
        return Task.FromResult(Result.From(account, result));
      }
      return Task.FromResult(Result.Fail<Account>($"Conta #{request.AccountNo} não encontrada"));
    }
  }
}