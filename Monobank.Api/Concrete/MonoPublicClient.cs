using Sentinelab.Monobank.Api.Abstract;
using Sentinelab.Monobank.Api.Helpers;
using Sentinelab.Monobank.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sentinelab.Monobank.Api.Concrete
{
    public class MonoPublicClient : IMonoPublicClient
    {
        private MonoHttpClient _monoHttpClient;

        public MonoPublicClient()
        {
            _monoHttpClient = new MonoHttpClient();
        }

        /// <inheritdoc />
        public async Task<IEnumerable<CurrencyInfo>> GetCurrenciesAsync()
        {
            return await _monoHttpClient.GetAsync<IEnumerable<CurrencyInfo>>(Constants.GetCurrencyResource).ConfigureAwait(false);
        }
    }
}
