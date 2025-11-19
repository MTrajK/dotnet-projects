namespace DotNet.MeaningfulUnitTests.Payments.Traditional.Controllers
{
    using DotNet.MeaningfulUnitTests.Payments.Traditional.DTOs;
    using DotNet.MeaningfulUnitTests.Payments.Traditional.Services;

    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }

        [HttpPost]
        public SplitPaymentResponse SplitPayment(SplitPaymentRequest request)
        {
            return this.paymentService.SplitPayment(request);
        }
    }
}
