using System.Collections.Generic;
using Newtonsoft.Json;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Dto
{
    public class BranchDto
    {
        [JsonProperty("identification")]
        public IdentificationDto Identification { get; set; }

        [JsonProperty("postalAddress")]
        public PostalAddressDto PostalAddress { get; set; }

        [JsonProperty("availability")]
        public AvailabilityDto Availability { get; set; }

        [JsonProperty("services")]
        public List<ServiceDto> Services { get; set; }
    }
}