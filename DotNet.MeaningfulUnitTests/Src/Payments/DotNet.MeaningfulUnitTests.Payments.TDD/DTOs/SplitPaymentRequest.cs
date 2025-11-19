namespace DotNet.MeaningfulUnitTests.Payments.TDD.DTOs
{
    public class SplitPaymentRequest
    {
        public long? AccountId { get; set; }

        public int? Amount { get; set; }

        public long? TransactionId { get; set; }

        public string? GatewayTransactionId { get; set; }
    }
}
