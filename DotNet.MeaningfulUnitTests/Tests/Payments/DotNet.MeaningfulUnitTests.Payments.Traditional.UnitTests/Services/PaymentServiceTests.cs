namespace DotNet.MeaningfulUnitTests.Payments.Traditional.UnitTests.Services
{
    using DotNet.MeaningfulUnitTests.Payments.Traditional.DTOs;
    using DotNet.MeaningfulUnitTests.Payments.Traditional.Repositories;
    using DotNet.MeaningfulUnitTests.Payments.Traditional.Services;
    using DotNet.MeaningfulUnitTests.Payments.Traditional.Utils;

    using FluentAssertions;

    using Moq;

    using System.Net;

    [TestClass]
    public class PaymentServiceTests
    {
        [TestMethod]
        public void SplitPayment_InvalidRequestMissingAccountId_ReturnsBadRequestCode()
        {
            // Arrange
            var accountId = (long?)null;
            var statusCode = HttpStatusCode.BadRequest;
            var splitPaymentRequest = new SplitPaymentRequest
            {
                AccountId = accountId
            };
            var splitPaymentResponse = new SplitPaymentResponse
            {
                AccountId = accountId,
                TransactionId = null,
                Amount = null,
                StatusCode = statusCode
            };

            var requestValidatorMock = new Mock<IRequestValidator>();
            requestValidatorMock
                .Setup(x => x.Validate(splitPaymentRequest))
                .Returns(false);

            var responseBuilderMock = new Mock<IResponseBuilder>();
            responseBuilderMock
                .Setup(x => x.FailedSplitPaymentResponse(accountId, statusCode))
                .Returns(splitPaymentResponse);

            var sut = new PaymentService(requestValidatorMock.Object, null, responseBuilderMock.Object);

            // Act
            var result = sut.SplitPayment(splitPaymentRequest);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void SplitPayment_InvalidRequestMissingBothTransactionId_ReturnsBadRequestCode()
        {
            // Arrange
            var accountId = (long?)123;
            var amount = 1000;
            var statusCode = HttpStatusCode.BadRequest;
            var splitPaymentRequest = new SplitPaymentRequest
            {
                AccountId = accountId,
                Amount = amount,
                TransactionId = null,
                GatewayTransactionId = null
            };
            var splitPaymentResponse = new SplitPaymentResponse
            {
                AccountId = accountId,
                TransactionId = null,
                Amount = null,
                StatusCode = statusCode
            };

            var requestValidatorMock = new Mock<IRequestValidator>();
            requestValidatorMock
                .Setup(x => x.Validate(splitPaymentRequest))
                .Returns(false);

            var responseBuilderMock = new Mock<IResponseBuilder>();
            responseBuilderMock
                .Setup(x => x.FailedSplitPaymentResponse(accountId, statusCode))
                .Returns(splitPaymentResponse);

            var sut = new PaymentService(requestValidatorMock.Object, null, responseBuilderMock.Object);

            // Act
            var result = sut.SplitPayment(splitPaymentRequest);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TestMethod]
        public void SplitPayment_TransactionIdNotFoundUsingGatewayTransactionId_ReturnsNotFoundCode()
        {
            // Arrange
            var accountId = (long?)123;
            var amount = 1000;
            var gatewayTransactionId = "1234";
            var statusCode = HttpStatusCode.NotFound;
            var splitPaymentRequest = new SplitPaymentRequest
            {
                AccountId = accountId,
                Amount = amount,
                TransactionId = null,
                GatewayTransactionId = gatewayTransactionId
            };
            var splitPaymentResponse = new SplitPaymentResponse
            {
                AccountId = accountId,
                TransactionId = null,
                Amount = null,
                StatusCode = statusCode
            };

            var requestValidatorMock = new Mock<IRequestValidator>();
            requestValidatorMock
                .Setup(x => x.Validate(splitPaymentRequest))
                .Returns(true);

            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            transactionRepositoryMock
                .Setup(x => x.GetTransactionIdUsingGatewayTransactionId(accountId.Value, gatewayTransactionId))
                .Returns((long?)null);

            var responseBuilderMock = new Mock<IResponseBuilder>();
            responseBuilderMock
                .Setup(x => x.FailedSplitPaymentResponse(accountId, statusCode))
                .Returns(splitPaymentResponse);

            var sut = new PaymentService(requestValidatorMock.Object, transactionRepositoryMock.Object, responseBuilderMock.Object);

            // Act
            var result = sut.SplitPayment(splitPaymentRequest);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.NotFound);
        }

        [TestMethod]
        public void SplitPayment_TransactionInsertFailedUsingTransactionId_ReturnsNotAcceptableCode()
        {
            // Arrange
            var accountId = (long?)123;
            var amount = 1000;
            var transactionId = (long?)1234;
            var statusCode = HttpStatusCode.NotAcceptable;
            var splitPaymentRequest = new SplitPaymentRequest
            {
                AccountId = accountId,
                Amount = amount,
                TransactionId = transactionId,
                GatewayTransactionId = null
            };
            var splitPaymentResponse = new SplitPaymentResponse
            {
                AccountId = accountId,
                TransactionId = null,
                Amount = null,
                StatusCode = statusCode
            };

            var requestValidatorMock = new Mock<IRequestValidator>();
            requestValidatorMock
                .Setup(x => x.Validate(splitPaymentRequest))
                .Returns(true);

            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            transactionRepositoryMock
                .Setup(x => x.InsertSplitPaymentTransaction(accountId.Value, transactionId.Value, amount))
                .Returns((long?)null);

            var responseBuilderMock = new Mock<IResponseBuilder>();
            responseBuilderMock
                .Setup(x => x.FailedSplitPaymentResponse(accountId, statusCode))
                .Returns(splitPaymentResponse);

            var sut = new PaymentService(requestValidatorMock.Object, transactionRepositoryMock.Object, responseBuilderMock.Object);

            // Act
            var result = sut.SplitPayment(splitPaymentRequest);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.NotAcceptable);
        }

        [TestMethod]
        public void SplitPayment_TransactionInsertSucceededUsingTransactionId_ReturnsOKCodeAndSplitPaymentTransactionId()
        {
            // Arrange
            var accountId = (long?)123;
            var amount = 1000;
            var transactionId = (long?)1234;
            var statusCode = HttpStatusCode.OK;
            var splitPaymentRequest = new SplitPaymentRequest
            {
                AccountId = accountId,
                Amount = amount,
                TransactionId = transactionId,
                GatewayTransactionId = null
            };
            var splitPaymentTransactionId = (long)12345;
            var splitPaymentResponse = new SplitPaymentResponse
            {
                AccountId = accountId,
                TransactionId = splitPaymentTransactionId,
                Amount = amount,
                StatusCode = statusCode
            };

            var requestValidatorMock = new Mock<IRequestValidator>();
            requestValidatorMock
                .Setup(x => x.Validate(splitPaymentRequest))
                .Returns(true);

            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            transactionRepositoryMock
                .Setup(x => x.InsertSplitPaymentTransaction(accountId.Value, transactionId.Value, amount))
                .Returns(splitPaymentTransactionId);

            var responseBuilderMock = new Mock<IResponseBuilder>();
            responseBuilderMock
                .Setup(x => x.SuccessSplitPaymentResponse(accountId.Value, splitPaymentTransactionId, amount))
                .Returns(splitPaymentResponse);

            var sut = new PaymentService(requestValidatorMock.Object, transactionRepositoryMock.Object, responseBuilderMock.Object);

            // Act
            var result = sut.SplitPayment(splitPaymentRequest);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.TransactionId.Should().Be(splitPaymentTransactionId);
        }

        [TestMethod]
        public void SplitPayment_TransactionInsertSucceededUsingGatewayTransactionId_ReturnsOKCodeAndSplitPaymentTransactionId()
        {
            // Arrange
            var accountId = (long?)123;
            var amount = 1000;
            var transactionId = (long?)1234;
            var gatewayTransactionId = "1234";
            var statusCode = HttpStatusCode.OK;
            var splitPaymentRequest = new SplitPaymentRequest
            {
                AccountId = accountId,
                Amount = amount,
                TransactionId = null,
                GatewayTransactionId = gatewayTransactionId
            };
            var splitPaymentTransactionId = (long)12345;
            var splitPaymentResponse = new SplitPaymentResponse
            {
                AccountId = accountId,
                TransactionId = splitPaymentTransactionId,
                Amount = amount,
                StatusCode = statusCode
            };

            var requestValidatorMock = new Mock<IRequestValidator>();
            requestValidatorMock
                .Setup(x => x.Validate(splitPaymentRequest))
                .Returns(true);

            var transactionRepositoryMock = new Mock<ITransactionRepository>();
            transactionRepositoryMock
                .Setup(x => x.GetTransactionIdUsingGatewayTransactionId(accountId.Value, gatewayTransactionId))
                .Returns(transactionId);
            transactionRepositoryMock
                .Setup(x => x.InsertSplitPaymentTransaction(accountId.Value, transactionId.Value, amount))
                .Returns(splitPaymentTransactionId);

            var responseBuilderMock = new Mock<IResponseBuilder>();
            responseBuilderMock
                .Setup(x => x.SuccessSplitPaymentResponse(accountId.Value, splitPaymentTransactionId, amount))
                .Returns(splitPaymentResponse);

            var sut = new PaymentService(requestValidatorMock.Object, transactionRepositoryMock.Object, responseBuilderMock.Object);

            // Act
            var result = sut.SplitPayment(splitPaymentRequest);

            // Assert
            result.Should().NotBeNull();
            result.StatusCode.Should().Be(HttpStatusCode.OK);
            result.TransactionId.Should().Be(splitPaymentTransactionId);
        }
    }
}
