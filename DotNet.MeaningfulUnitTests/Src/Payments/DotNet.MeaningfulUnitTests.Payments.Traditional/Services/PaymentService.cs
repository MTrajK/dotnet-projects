namespace DotNet.MeaningfulUnitTests.Payments.Traditional.Services
{
    using DotNet.MeaningfulUnitTests.Payments.Traditional.DTOs;
    using DotNet.MeaningfulUnitTests.Payments.Traditional.Repositories;
    using DotNet.MeaningfulUnitTests.Payments.Traditional.Utils;

    using System.Net;

    public class PaymentService : IPaymentService
    {
        private readonly IRequestValidator requestValidator;
        private readonly ITransactionRepository transactionRepository;
        private readonly IResponseBuilder responseBuilder;

        public PaymentService(IRequestValidator requestValidator, ITransactionRepository transactionRepository, IResponseBuilder responseBuilder)
        { 
            this.requestValidator = requestValidator;
            this.transactionRepository = transactionRepository;
            this.responseBuilder = responseBuilder;
        }

        public SplitPaymentResponse SplitPayment(SplitPaymentRequest request)
        {
            var isValidRequest = this.requestValidator.Validate(request);
            if (!isValidRequest)
            {
                return this.responseBuilder.FailedSplitPaymentResponse(request.AccountId, HttpStatusCode.BadRequest);
            }

            long? transactionId = null;
            if (request.TransactionId == null)
            {
                transactionId = this.transactionRepository.GetTransactionIdUsingGatewayTransactionId(request.AccountId!.Value, request.GatewayTransactionId!);

                if (transactionId == null)
                {
                    return this.responseBuilder.FailedSplitPaymentResponse(request.AccountId, HttpStatusCode.NotFound);
                }
            }
            else
            {
                transactionId = request.TransactionId;
            }

            var splitPaymentTransactionId = this.transactionRepository.InsertSplitPaymentTransaction(request.AccountId!.Value, transactionId!.Value, request.Amount!.Value);
            if (splitPaymentTransactionId == null)
            {
                return this.responseBuilder.FailedSplitPaymentResponse(request.AccountId, HttpStatusCode.NotAcceptable);
            }

            return this.responseBuilder.SuccessSplitPaymentResponse(request.AccountId!.Value, splitPaymentTransactionId!.Value, request.Amount!.Value);
        }
    }
}
