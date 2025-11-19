namespace DotNet.MeaningfulUnitTests.Payments.Traditional.Utils
{
    using DotNet.MeaningfulUnitTests.Payments.Traditional.DTOs;

    using System.Net;

    public interface IResponseBuilder
    {
        public SplitPaymentResponse FailedSplitPaymentResponse(long? accountId, HttpStatusCode statusCode);

        public SplitPaymentResponse SuccessSplitPaymentResponse(long accountId, long transactionId, int amount);
    }
}
