using Bank.Domain.Accounts.Base;
using Bank.Domain.Entities;

namespace Bank.Domain.Accounts.Withdraw
{
  public class WithdrawCommand : AccountCommand<Account>
  {
    public decimal Amount { get; set; }
  }
}