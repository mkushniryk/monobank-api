using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Sentinelab.Monobank.Api.Exceptions;
using Sentinelab.Monobank.Api.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Sentinelab.Monobank.Api.Helpers
{
    internal class MonoHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerSettings _serializerSettings;

        private const string ContentType = "application/json";

        public MonoHttpClient()
        {
            _serializerSettings = new JsonSerializerSettings
            { ContractResolver = new CamelCasePropertyNamesContractResolver() };

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(Constants.MonobankHost),
            };
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(ContentType));
        }

        public MonoHttpClient(string token) : this()
        {
            _httpClient.DefaultRequestHeaders.Add("X-Token", token);
        }

        public async Task<T> GetAsync<T>(string url)
        {
            using (var response = await _httpClient.GetAsync(url).ConfigureAwait(false))
            {
                return await ReadResponseAsync<T>(response).ConfigureAwait(false);
            }
        }

        public async Task PostAsync(string url, object request)
        {
            var body = JsonConvert.SerializeObject(request, _serializerSettings);
            using (var content = new StringContent(body, Encoding.UTF8, ContentType))
            {
                using (var response = await _httpClient.PostAsync(url, content).ConfigureAwait(false))
                {
                    await ReadResponseAsync(response).ConfigureAwait(false);
                }
            }
        }

        private async Task<T> ReadResponseAsync<T>(HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<Error>(result, _serializerSettings);
                throw new MonobankException(error.Description);
            }

            return JsonConvert.DeserializeObject<T>(result, _serializerSettings);
        }

        private async Task ReadResponseAsync(HttpResponseMessage response)
        {
            var result = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                var error = JsonConvert.DeserializeObject<Error>(result, _serializerSettings);
                throw new MonobankException(error.Description);
            }
        }
    }
}
