using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Monobank.Api.Client.Models;
using Monobank.Api.Client.Models.Requests;
using Monobank.Api.Client.Extensions;
using Monobank.Api.Client.Abstractions;
using RestSharp;

namespace Monobank.Api.Client.Clients
{
    internal class MonobankClient : RestApiClient, IMonobankClient
    {
        public MonobankClient(string token)
            : base(Constants.ApiGatewayPath, Constants.AuthTokenKey, token)
        {

        }

        /// <inheritdoc/>
        public async Task<ClientInfo> GetClientInfoAsync()
        {
            var response = await ExecuteAsync<ClientInfo>(Constants.GetClientInfoResource, Method.GET);
            return response.Data;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<StatementItem>> GetStatementAsync(string accountId, long from, long? to = null)
        {
            var resourcePath = $"{Constants.GetStatementResource}/{accountId}/{from}";

            if (to.HasValue)
                resourcePath = $"{resourcePath}/{to.Value}";

            var response = await ExecuteAsync<IEnumerable<StatementItem>>(resourcePath, Method.GET);
            return response.Data;
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<StatementItem>> GetStatementAsync(long from, long? to = null)
        {
            return await GetStatementAsync(Constants.DefaultUserAccount, from, to);
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<StatementItem>> GetStatementAsync(string accountId, DateTime from, DateTime? to = null)
        {
            return await GetStatementAsync(accountId, from.ToUnixSeconds(), to.HasValue ? (long?)to.Value.ToUnixSeconds() : null);
        }
        /// <inheritdoc/>
        public async Task<IEnumerable<StatementItem>> GetStatementAsync(DateTime from, DateTime? to = null)
        {
            return await GetStatementAsync(Constants.DefaultUserAccount, from.ToUnixSeconds(), to.HasValue ? (long?)to.Value.ToUnixSeconds() : null);
        }

        /// <inheritdoc/>
        public async Task<IRestResponse> SetWebHookAsync(string webHookUrl)
        {
            var request = new SetWebHookRequest
            {
                WebHookUrl = webHookUrl
            };
            return await ExecuteAsync(Constants.SetWebHook, Method.POST, request);
        }
    }
}