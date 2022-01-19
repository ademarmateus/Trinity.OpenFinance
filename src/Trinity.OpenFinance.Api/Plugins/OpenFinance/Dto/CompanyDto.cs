using System.Collections.Generic;
using Newtonsoft.Json;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Dto
{
    public class CompanyDto
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("cnpjNumber")]
        public string CnpjNumber { get; set; }

        [JsonProperty("branches")]
        public List<BranchDto> Branches { get; set; }
    }
}