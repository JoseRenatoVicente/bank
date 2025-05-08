using Bank.Domain.Contracts;
using Bank.Core.Domain.SeedWork;
using Bank.Domain.Fixeds;

namespace Bank.Domain.Events
{
  public sealed class CalculatedIncomeEvent : AccountEvent
  {
    public CalculatedIncomeEvent(IYieldAccount account, decimal amount)
        : base(account, EventType.Income, amount)
    {

    }
  }
}