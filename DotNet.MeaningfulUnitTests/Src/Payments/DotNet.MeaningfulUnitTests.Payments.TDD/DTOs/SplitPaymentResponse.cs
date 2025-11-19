namespace DotNet.MeaningfulUnitTests.Payments.TDD.DTOs
{
    using System.Net;

    public class SplitPaymentResponse
    {
        public long? AccountId { get; set; }

        public long? TransactionId { get; set; }

        public int? Amount { get; set; }

        public HttpStatusCode? StatusCode { get; set; }
    }
}
