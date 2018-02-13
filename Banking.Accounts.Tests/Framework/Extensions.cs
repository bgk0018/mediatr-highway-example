using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Banking.Accounts.Tests.Framework
{
    public static class Extensions
    {
        public static async Task<TResponse> PostAsJsonAsync<TRequest, TResponse>(this HttpClient client, string endpoint, TRequest payload)
        {
            var result = await client.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));

            return JsonConvert.DeserializeObject<TResponse>(await result.Content.ReadAsStringAsync());
        }

        public static async Task<T> GetAsync<T>(this HttpClient client, string endpoint)
        {
            var result = await client.GetStringAsync(endpoint);

            return JsonConvert.DeserializeObject<T>(result);
        }
    }
}
