using Bank.Core.Domain.Models;
using Bank.Domain.Contracts;
using Bank.Domain.ValueObjects;


namespace Bank.Domain.Services
{
  public class PaymentService : IPaymentService
  {
    public Result Pay(IPaybleAccount account, Invoice invoice)
    {
      if (account.CanCharge(invoice))
      {
        account.ChargePayment(invoice);
        return Result.Ok();
      }
      return Result.Fail("Não foi possível realizar o pagamento");
    }
  }
}