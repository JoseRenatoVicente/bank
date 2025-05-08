using System.Collections.Generic;
using System;
using System.Linq;

using Bank.Domain.Contracts;
using Bank.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using Bank.Infra.Contexts;

namespace Bank.Infra.Repositories
{
  public class AccountRepository : IAccountRepository
  {
    private readonly BankDbContext _context;
    private readonly DbSet<Account> _dbSet;

    public AccountRepository(BankDbContext context)
    {
      _context = context;
      _dbSet = context.Set<Account>();
    }

    public Account GetById(int accountNo)
    {
      return _dbSet.Find(accountNo);
    }

    public IEnumerable<Account> GetAll()
    {
      return _dbSet.ToArray();
    }

    public void Add(Account account)
    {
      _dbSet.Add(account);
    }

    public void Update(Account account)
    {
      _dbSet.Attach(account);
      _context.Entry(account).State = EntityState.Modified;
    }

    public void Delete(int accountNo)
    {
      var entity = GetById(accountNo);
      _dbSet.Remove(entity);
    }

    public void SaveChanges()
    {
      _context.SaveChanges();
    }
  }
}