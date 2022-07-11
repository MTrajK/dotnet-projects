using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace DotNet.TDD.DeskBooking.IntegrationTests.Utils
{
    public static class HttpContentUtils
    {
        public static async Task<long?> ReadAsLong(this HttpContent content)
        {
            var stringValue = await content.ReadAsStringAsync();

            return long.Parse(stringValue);
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
