namespace DotNet.IntegrationTesting.Demo2.IntegrationTests.Stubs
{
    using DotNet.IntegrationTesting.Demo2.Application.IService;

    public class CatFactsStubService : ICatFactsService
    {
        private const string _stubServiceResponse = "Cats have 3 eyelids.";

        public Task<string?> GetRandomCatFact(int maxLength)
        {
            return Task.FromResult<string?>(_stubServiceResponse);
        }
    }
}
