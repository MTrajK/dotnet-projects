namespace DotNet.MeaningfulUnitTests.Payments.TDD.Utils
{
    using DotNet.MeaningfulUnitTests.Payments.TDD.DTOs;

    public class RequestValidator : IRequestValidator
    {
        public bool Validate(SplitPaymentRequest request)
        {
            if (request.AccountId == null)
            {
                return false;
            }

            if (request.Amount == null) 
            {
                return false;
            }

            if (request.TransactionId == null && string.IsNullOrEmpty(request.GatewayTransactionId))
            {
                return false;
            }

            if (request.TransactionId != null && !string.IsNullOrEmpty(request.GatewayTransactionId))
            {
                return false;
            }

            return true; 
        }
    }
}
