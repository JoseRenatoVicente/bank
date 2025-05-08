using System.ComponentModel.DataAnnotations;

using Bank.Domain.Accounts.Base;
using Bank.Domain.DTOs;
using Bank.Domain.Entities;

namespace Bank.Domain.Accounts.Payment
{
  public sealed class PaymentCommand : AccountCommand<Account>
  {
    [Display(Name = "Boleto")]
    [Required(ErrorMessage = "O campo '{0}' é obrigatório")]
    public InvoiceDto Invoice { get; set; }

  }
}