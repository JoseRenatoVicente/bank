using Bank.Domain.ValueObjects;

namespace Bank.Domain.Contracts
{
  public interface IPaybleAccount : IAccount
  {
    bool CanCharge(Invoice invoice);

    void ChargePayment(Invoice invoice);
  }
}