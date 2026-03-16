using Microsoft.AspNetCore.Mvc;
using PaymentsService.Api.Services;

namespace PaymentsService.Api.Controllers;

[ApiController]
[Route("api/payments")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentService _paymentService;

    public PaymentsController(IPaymentService paymentService)
    {
        _paymentService = paymentService;
    }

    [HttpGet]
    public IActionResult GetPayments()
    {
        var payments = _paymentService.GetPayments();
        return Ok(payments);
    }
}