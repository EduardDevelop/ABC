using PaymentsService.Api.Models;

namespace PaymentsService.Api.Services;

public interface IPaymentService
{
    IEnumerable<PaymentDto> GetPayments();
}