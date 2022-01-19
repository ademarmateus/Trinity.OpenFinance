using System.Collections.Generic;
using Newtonsoft.Json;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Dto
{
    public class AvailabilityDto
    {
        [JsonProperty("standards")]
        public List<StandardDto> Standards { get; set; }

        [JsonProperty("exception")]
        public string Exception { get; set; }
    }
}