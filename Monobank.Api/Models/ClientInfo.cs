using System.Collections.Generic;

namespace Monobank.Api.Client.Models
{
    /// <summary>
    /// Description of the client and his accounts
    /// </summary>
    public class ClientInfo
    {
        /// <summary>
        /// Client name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// URL to get information about the new transaction
        /// </summary>
        public string WebHookUrl { get; set; }

        /// <summary>
        /// List of available accounts
        /// </summary>
        public IEnumerable<Account> Accounts { get; set; }
    }
}