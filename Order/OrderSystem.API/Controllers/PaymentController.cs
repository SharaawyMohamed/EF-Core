using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class PaymentController : ControllerBase
    {
        private readonly IPayPalPayment _payPalPayment;

        public PaymentController(IPayPalPayment payPalPayment)
        {
            _payPalPayment = payPalPayment;
        }

        [HttpPost("PayPalPayment")]
        public async Task<IActionResult> PayPalPayment([FromBody] PaymentRequestDto paymentRequest)
        {
            try
            {
                var invoice = await _payPalPayment.PaymentWithPayPal(paymentRequest.OrderId);
                return Ok(invoice);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }

    public class PaymentRequestDto
    {
        public int OrderId { get; set; }
    }
}
