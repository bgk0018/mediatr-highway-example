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
            var response = await client.PostAsync(endpoint, new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
            }

            return default(TResponse);
        }

        public static async Task<TResponse> GetAsync<TResponse>(this HttpClient client, string endpoint)
        {
            var response = await client.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<TResponse>(await response.Content.ReadAsStringAsync());
            }

            return default(TResponse);
        }
    }
}
