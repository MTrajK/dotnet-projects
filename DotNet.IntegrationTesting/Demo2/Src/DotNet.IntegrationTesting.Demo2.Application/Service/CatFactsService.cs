namespace DotNet.IntegrationTesting.Demo2.Application.Service
{
    using Newtonsoft.Json;

    using DotNet.IntegrationTesting.Demo2.Application.DTOs;
    using DotNet.IntegrationTesting.Demo2.Application.IService;

    public class CatFactsService : ICatFactsService
    {
        private const string _catFactsApiUri = "https://catfact.ninja/fact?max_length={0}";

        private readonly HttpClient _httpClient;

        public CatFactsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string?> GetRandomCatFact(int maxLength)
        {
            var uri = string.Format(_catFactsApiUri, maxLength);

            var response = await _httpClient.GetAsync(uri);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var jsonResult = await response.Content.ReadAsStringAsync();
            var catFact = JsonConvert.DeserializeObject<CatFact>(jsonResult);

            return catFact?.Fact;
        }
    }
}
