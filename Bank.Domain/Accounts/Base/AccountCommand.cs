using Bank.Core.Domain.Models;
using Bank.Domain.Contracts;

using MediatR;

namespace Bank.Domain.Accounts.Base
{
  public abstract class AccountCommand<TAccount> : IRequest<Result<TAccount>> where TAccount : IAccount
  {
    public int AccountNo { get; set; }
  }
}