using Newtonsoft.Json;

namespace Monobank.Api.Client.Models
{
    public class Error
    {
        /// <summary>
        /// Error text for the end user
        /// </summary>
        [JsonProperty("errorDescription")]
        public string Description { get; set; }
    }
}