namespace DotNet.MeaningfulUnitTests.Payments.TDD.Utils
{
    using DotNet.MeaningfulUnitTests.Payments.TDD.DTOs;

    public interface IRequestValidator
    {
        public bool Validate(SplitPaymentRequest request);
    }
}
