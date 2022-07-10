namespace DotNet.TDD.DeskBooking.IntegrationTests.Utils
{
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public static class HttpContentUtils
    {
        public static async Task<int?> ReadAsInt(this HttpContent content)
        {
            var stringValue = await content.ReadAsStringAsync();

            return int.Parse(stringValue);
        }

        public static async Task<T> ReadAsDTO<T>(this HttpContent content)
        {
            var stringValue = await content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(stringValue);
        }

        public static ByteArrayContent IncludeDataToHttpContent<T>(T data)
        {
            var myContent = JsonConvert.SerializeObject(data);
            var buffer = System.Text.Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return byteContent;
        }
    }
}
