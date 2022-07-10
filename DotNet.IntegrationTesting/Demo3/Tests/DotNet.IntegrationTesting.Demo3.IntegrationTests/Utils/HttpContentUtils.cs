namespace DotNet.IntegrationTesting.Demo3.IntegrationTests.Utils
{
    using System.Threading.Tasks;

    public static class HttpContentUtils
    {
        public static async Task<int?> ReadAsInt(this HttpContent content)
        {
            var stringValue = await content.ReadAsStringAsync();

            return int.Parse(stringValue);
        }
    }
}
