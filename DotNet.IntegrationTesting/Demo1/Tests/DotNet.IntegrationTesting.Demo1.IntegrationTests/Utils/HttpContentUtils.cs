namespace DotNet.IntegrationTesting.Demo1.IntegrationTests.Utils
{
    using System.Threading.Tasks;

    public static class HttpContentUtils
    {
        public static async Task<double?> ReadAsDouble(this HttpContent content)
        {
            var stringValue = await content.ReadAsStringAsync();

            return double.Parse(stringValue);
        }
    }
}
