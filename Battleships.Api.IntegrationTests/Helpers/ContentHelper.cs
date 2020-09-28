using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace Battleships.Api.IntegrationTests.Helpers
{
    public static class ContentHelper
    {
        public static StringContent Serialize(object obj)
            => new StringContent(JsonConvert.SerializeObject(obj), Encoding.Default, "application/json");

        public static T Deserialize<T>(string stringContent)
            => JsonConvert.DeserializeObject<T>(stringContent);
    }
}
