using Bank.Domain.Accounts.Base;
using Bank.Domain.Entities;

namespace Bank.Domain.Accounts.Deposit
{
  public sealed class DepositCommand : AccountCommand<Account>
  {
    public decimal Amount { get; set; }
  }
}