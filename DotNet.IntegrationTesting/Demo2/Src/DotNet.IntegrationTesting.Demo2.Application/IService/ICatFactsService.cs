namespace DotNet.IntegrationTesting.Demo2.Application.IService
{
    public interface ICatFactsService
    {
        public Task<string?> GetRandomCatFact(int maxLength);
    }
}
