using Newtonsoft.Json;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Dto
{
    public class MetaDto
    {
        [JsonProperty("totalRecords")]
        public int TotalRecords { get; set; }

        [JsonProperty("totalPages")]
        public int TotalPages { get; set; }
    }
}