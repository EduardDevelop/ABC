using PaymentsService.Api.Models;

namespace PaymentsService.Api.Services;

public class PaymentService : IPaymentService
{
    public IEnumerable<PaymentDto> GetPayments()
    {
        return new List<PaymentDto>
        {
            new PaymentDto
            {
                Id = 1,
                PaymentReference = "PAY-1001",
                Amount = 150.75m,
                Currency = "USD",
                Status = "Completed"
            },
            new PaymentDto
            {
                Id = 2,
                PaymentReference = "PAY-1002",
                Amount = 80.20m,
                Currency = "USD",
                Status = "Pending"
            }
        };
    }
}