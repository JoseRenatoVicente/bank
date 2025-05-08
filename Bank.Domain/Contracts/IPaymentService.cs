using Bank.Core.Domain.Models;
using Bank.Domain.ValueObjects;

namespace Bank.Domain.Contracts
{
  public interface IPaymentService
  {
    Result Pay(IPaybleAccount account, Invoice invoice);
  }
}