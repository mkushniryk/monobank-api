using System.Threading.Tasks;
using System.Collections.Generic;
using Monobank.Api.Client.Models;
using Monobank.Api.Client.Clients;
using Monobank.Api.Client.Abstractions;

namespace Monobank.Api.Client
{
    public static class MonobankApi
    {
        public static IMonobankClient Create(string token)
        {
            var client = new MonobankClient(token);
            return client;
        }

        public static async Task<IEnumerable<CurrencyInfo>> GetCurrenciesAsync()
        {
            var client = new RestApiClient(Constants.ApiGatewayPath);

            var response = (await client.ExecuteAsync<IEnumerable<CurrencyInfo>>(Constants.GetCurrencyResource, RestSharp.Method.GET)).Data;
            return response;
        }
    }
}