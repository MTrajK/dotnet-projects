namespace DotNet.MeaningfulUnitTests.Payments.Traditional.Utils
{
    using DotNet.MeaningfulUnitTests.Payments.Traditional.DTOs;

    using System.Net;

    public class ResponseBuilder : IResponseBuilder
    {
        public SplitPaymentResponse FailedSplitPaymentResponse(long? accountId, HttpStatusCode statusCode)
        {
            return new SplitPaymentResponse
            {
                AccountId = accountId,
                TransactionId = null,
                Amount = null,
                StatusCode = statusCode
            };
        }

        public SplitPaymentResponse SuccessSplitPaymentResponse(long accountId, long transactionId, int amount)
        {
            return new SplitPaymentResponse
            {
                AccountId = accountId,
                TransactionId = transactionId,
                Amount = amount,
                StatusCode = HttpStatusCode.OK
            };
        }
    }
}
