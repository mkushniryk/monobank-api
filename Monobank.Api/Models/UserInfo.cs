using System.Collections.Generic;

namespace Sentinelab.Monobank.Api.Models
{
    /// <summary>
    /// Опис клієнта та його рахунків
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// Ім'я клієнта
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// URL для отримання інформації про нову транзакцію
        /// </summary>
        public string WebHookUrl { get; set; }

        /// <summary>
        /// Перелік доступних рахунків
        /// </summary>
        public IEnumerable<Account> Accounts { get; set; }
    }
}
