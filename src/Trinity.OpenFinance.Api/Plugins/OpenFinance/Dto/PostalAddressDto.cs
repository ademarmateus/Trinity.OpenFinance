using Newtonsoft.Json;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Dto
{
    public class PostalAddressDto
    {
        [JsonProperty("address")]
        public string Address { get; set; }

        [JsonProperty("districtName")]
        public string DistrictName { get; set; }

        [JsonProperty("townName")]
        public string TownName { get; set; }

        [JsonProperty("countrySubDivision")]
        public string CountrySubDivision { get; set; }

        [JsonProperty("postCode")]
        public string PostCode { get; set; }

        [JsonProperty("additionalInfo")]
        public string AdditionalInfo { get; set; }
    }
}