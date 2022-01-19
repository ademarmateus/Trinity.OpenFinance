using Newtonsoft.Json;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Dto
{
    public class IdentificationDto
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("checkDigit")]
        public string CheckDigit { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}