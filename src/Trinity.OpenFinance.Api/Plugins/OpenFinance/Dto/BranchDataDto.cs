using Newtonsoft.Json;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Dto
{
    public class BranchDataDto
    {
        [JsonProperty("data")]
        public DataDto Data { get; set; }

        [JsonProperty("links")]
        public LinksDto Links { get; set; }

        [JsonProperty("meta")]
        public MetaDto Meta { get; set; }
    }


}