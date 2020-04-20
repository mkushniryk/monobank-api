namespace Sentinelab.Monobank.Api.Models
{
    /// <summary>
    /// Рахунок
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Ідентифікатор рахунку
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Баланс рахунку в мінімальних одиницях валюти (копійках, центах)
        /// </summary>
        public long Balance { get; set; }

        /// <summary>
        /// Кредитний ліміт
        /// </summary>
        public long CreditLimit { get; set; }

        /// <summary>
        /// Код валюти рахунку відповідно ISO 4217
        /// </summary>
        public int CurrencyCode { get; set; }

        /// <summary>
        /// Тип кешбеку який нараховується на рахунок: None, UAH, Miles 
        /// </summary>
        public string CashbackType { get; set; }
    }
}
