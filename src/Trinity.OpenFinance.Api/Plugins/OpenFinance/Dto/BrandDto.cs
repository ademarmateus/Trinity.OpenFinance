using System.Collections.Generic;
using Newtonsoft.Json;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Dto
{
    public class BrandDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("companies")]
        public List<CompanyDto> Companies { get; set; }
    }
}