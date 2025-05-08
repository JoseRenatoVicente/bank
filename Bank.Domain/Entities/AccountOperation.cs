using System;

using Bank.Core.Domain.SeedWork;
using Bank.Domain.Fixeds;

namespace Bank.Domain.Entities
{
  public class AccountOperation
  {
    private AccountOperation()
    {
    }

    public AccountOperation(DateTime date, string description, decimal amount, EventType operation)
    {
      Date = date;
      Description = description;
      Amount = amount;
      Operation = operation;
    }

    public int Id { get; }
    public DateTime Date { get; private set; }
    public string Description { get; private set; }
    public decimal Amount { get; private set; }
    public EventType Operation { get; private set; }
    public int AccountNo { get; set; }
    public Account Account { get; set; }
  }
}
