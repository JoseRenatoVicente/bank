using Bank.Core.Domain.Models;
using Bank.Domain.Entities;
using Bank.Domain.ValueObjects;

namespace Bank.Domain.Contracts
{
  public interface IAccount
  {
    int No { get; }

    Owner Owner { get; }

    Result Withdraw(decimal amount);

    decimal Balance { get; }

    void AddOperation(AccountOperation accountHistory);
  }
}