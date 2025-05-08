using System;

using MediatR;

namespace Bank.Domain.Accounts.CalculateIncome
{
  public class CalculateIncomeCommand : IRequest
  {
    public DateTime ForDate { get; set; }
    public double InterestRate { get; set; }
  }
}