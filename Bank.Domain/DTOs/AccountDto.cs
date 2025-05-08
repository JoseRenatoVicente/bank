using System.Collections.Generic;
using System.Linq;

using Bank.Domain.Entities;

namespace Bank.Domain.DTOs
{
  public class AccountDto
  {
    public AccountDto(int accountNo, string title, decimal balance, IEnumerable<AccountStatementDto> statements)
    {
      AccountNo = accountNo;
      Title = title;
      Statements = statements;
      Balance = balance;
    }

    public int AccountNo { get; }
    public string Title { get; }
    public decimal Balance { get; }

    public IEnumerable<AccountStatementDto> Statements { get; }

    public static implicit operator AccountDto(Account entity)
    {
      var stats = entity.Operations.Select(h => (AccountStatementDto)h);
      return new(entity.No, entity.Owner?.Title, entity.Balance, stats);
    }
  }
}