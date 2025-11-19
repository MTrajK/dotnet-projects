namespace DotNet.MeaningfulUnitTests.Payments.Traditional.Services
{
    using DotNet.MeaningfulUnitTests.Payments.Traditional.DTOs;

    public interface IPaymentService
    {
        public SplitPaymentResponse SplitPayment(SplitPaymentRequest request);
    }
}
