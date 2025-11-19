namespace DotNet.MeaningfulUnitTests.Payments.Traditional.Utils
{
    using DotNet.MeaningfulUnitTests.Payments.Traditional.DTOs;

    public interface IRequestValidator
    {
        public bool Validate(SplitPaymentRequest request);
    }
}
