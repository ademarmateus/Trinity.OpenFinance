using Newtonsoft.Json;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Dto
{
    public class StandardDto
    {
        [JsonProperty("weekday")]
        public string Weekday { get; set; }

        [JsonProperty("openingTime")]
        public string OpeningTime { get; set; }

        [JsonProperty("closingTime")]
        public string ClosingTime { get; set; }
    }
}