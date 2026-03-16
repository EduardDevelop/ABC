namespace PaymentsService.Api.Models;

public class PaymentDto
{
    public int Id { get; set; }

    public string PaymentReference { get; set; } = string.Empty;

    public decimal Amount { get; set; }

    public string Currency { get; set; } = "USD";

    public string Status { get; set; } = string.Empty;
}