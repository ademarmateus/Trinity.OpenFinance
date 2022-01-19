using Newtonsoft.Json;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Dto
{
    public class LinksDto
    {
        [JsonProperty("self")]
        public string Self { get; set; }

        [JsonProperty("first")]
        public string First { get; set; }

        [JsonProperty("prev")]
        public object Prev { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }
    }
}