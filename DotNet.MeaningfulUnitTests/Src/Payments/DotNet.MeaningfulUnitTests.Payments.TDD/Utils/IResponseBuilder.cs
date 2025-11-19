namespace DotNet.MeaningfulUnitTests.Payments.TDD.Utils
{
    using DotNet.MeaningfulUnitTests.Payments.TDD.DTOs;

    using System.Net;

    public interface IResponseBuilder
    {
        public SplitPaymentResponse FailedSplitPaymentResponse(long? accountId, HttpStatusCode statusCode);

        public SplitPaymentResponse SuccessSplitPaymentResponse(long accountId, long transactionId, int amount);
    }
}
