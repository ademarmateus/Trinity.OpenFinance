using Newtonsoft.Json;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Dto
{
    public class DataDto
    {
        [JsonProperty("brand")]
        public BrandDto Brand { get; set; }
    }
}