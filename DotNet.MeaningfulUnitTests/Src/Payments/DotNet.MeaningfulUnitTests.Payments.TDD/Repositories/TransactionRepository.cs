namespace DotNet.MeaningfulUnitTests.Payments.TDD.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        public long? GetTransactionIdUsingGatewayTransactionId(long accountId, string gatewayTransactionId)
        {
            if (accountId <= 0 || gatewayTransactionId == "")
            {
                return null;
            }

            return new Random().Next(10000, 20000);
        }

        public long? InsertSplitPaymentTransaction(long accountId, long transactionId, int amount)
        {
            if (amount <= 0)
            {
                return null;
            }

            return new Random().Next(10000, 20000);
        }
    }
}
