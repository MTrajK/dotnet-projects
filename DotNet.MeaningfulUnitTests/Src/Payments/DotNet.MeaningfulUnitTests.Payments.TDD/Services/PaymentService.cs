namespace DotNet.MeaningfulUnitTests.Payments.TDD.Services
{
    using DotNet.MeaningfulUnitTests.Payments.TDD.Repositories;
    using DotNet.MeaningfulUnitTests.Payments.TDD.Utils;

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

        // TODO: TDD way
    }
}
