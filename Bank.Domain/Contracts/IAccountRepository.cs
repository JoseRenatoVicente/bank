using System.Collections.Generic;

using Bank.Domain.Entities;

namespace Bank.Domain.Contracts
{
  public interface IAccountRepository
  {
    Account GetById(int accountNo);
    IEnumerable<Account> GetAll();
    void Add(Account account);
    void Update(Account account);
    void Delete(int accountNo);
    void SaveChanges();
  }
}