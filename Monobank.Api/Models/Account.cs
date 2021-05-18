namespace Monobank.Api.Client.Models
{
    /// <summary>
    /// Client account
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Account Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Account balance in minimum currency units
        /// </summary>
        public long Balance { get; set; }

        /// <summary>
        /// Account credit limit
        /// </summary>
        public long CreditLimit { get; set; }

        /// <summary>
        /// Account currency code according to ISO 4217
        /// </summary>
        public int CurrencyCode { get; set; }

        /// <summary>
        /// The type of cashback that is credited to the account: None, UAH, Miles
        /// </summary>
        public string CashbackType { get; set; }
    }
}