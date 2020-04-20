using Sentinelab.Monobank.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sentinelab.Monobank.Api.Abstract
{
    public interface IMonoPublicClient
    {
        /// <summary>
        /// Отримати базовий перелік курсів валют monobank. Інформація кешується та оновлюється не частіше 1 разу на 5 хвилин.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CurrencyInfo>> GetCurrenciesAsync();
    }
}
