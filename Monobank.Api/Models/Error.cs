using Newtonsoft.Json;

namespace Sentinelab.Monobank.Api.Models
{
    public class Error
    {
        /// <summary>
        /// Текст помилки для кінцевого користувача
        /// </summary>
        [JsonProperty("errorDescription")]
        public string Description { get; set; }
    }
}
