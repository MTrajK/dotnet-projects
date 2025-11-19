namespace DotNet.MeaningfulUnitTests.Payments.Traditional.Repositories
{
    public interface ITransactionRepository
    {
        public long? GetTransactionIdUsingGatewayTransactionId(long accountId, string gatewayTransactionId);

        public long? InsertSplitPaymentTransaction(long accountId, long transactionId, int amount);
    }
}
