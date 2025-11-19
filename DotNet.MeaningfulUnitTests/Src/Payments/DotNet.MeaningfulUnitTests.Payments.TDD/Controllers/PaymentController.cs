namespace DotNet.MeaningfulUnitTests.Payments.TDD.Controllers
{
    using DotNet.MeaningfulUnitTests.Payments.TDD.DTOs;
    using DotNet.MeaningfulUnitTests.Payments.TDD.Services;

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
            return null; // TODO: TDD way - this.paymentService.SplitPayment(request);
        }
    }
}
