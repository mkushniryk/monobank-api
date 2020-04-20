using Sentinelab.Monobank.Api.Abstract;
using Sentinelab.Monobank.Api.Extensions;
using Sentinelab.Monobank.Api.Helpers;
using Sentinelab.Monobank.Api.Models;
using Sentinelab.Monobank.Api.Models.Requests;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sentinelab.Monobank.Api.Concrete
{
    public class MonoPersonalClient : IMonoPersonalClient
    {
        private MonoHttpClient _monoHttpClient;

        public MonoPersonalClient(string token)
        {
            _monoHttpClient = new MonoHttpClient(token);
        }

        /// <inheritdoc />
        public async Task<UserInfo> GetUserInfo()
        {
            return await _monoHttpClient.GetAsync<UserInfo>(Constants.GetClientInfoResource).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public async Task<IEnumerable<StatementItem>> GetStatement(string accountId, long from, long? to = null)
        {
            var resourcePath = $"{Constants.GetStatementResource}/{accountId}/{from}";

            if (to.HasValue)
                resourcePath = $"{resourcePath}/{to.Value}";

            return await _monoHttpClient.GetAsync<IEnumerable<StatementItem>>(resourcePath).ConfigureAwait(false);
        }

        /// <inheritdoc />
        public Task<IEnumerable<StatementItem>> GetStatement(long from, long? to = null)
        {
            return GetStatement(Constants.DefaultUserAccount, from, to);
        }

        /// <inheritdoc />
        public Task<IEnumerable<StatementItem>> GetStatement(string accountId, DateTime from, DateTime? to = null)
        {
            return GetStatement(accountId, from.ToUnixSeconds(), to.HasValue ? (long?)to.Value.ToUnixSeconds() : null);
        }

        /// <inheritdoc />
        public Task<IEnumerable<StatementItem>> GetStatement(DateTime from, DateTime? to = null)
        {
            return GetStatement(Constants.DefaultUserAccount, from, to);
        }

        /// <inheritdoc />
        public async Task SetWebHook(string webHookUrl)
        {
            var request = new SetWebHookRequest
            {
                WebHookUrl = webHookUrl
            };
            await _monoHttpClient.PostAsync(Constants.SetWebHook, request).ConfigureAwait(false);
        }
    }
}
