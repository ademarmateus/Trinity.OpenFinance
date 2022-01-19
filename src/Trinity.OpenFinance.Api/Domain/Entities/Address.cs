namespace Trinity.OpenFinance.Api.Domain.Entities
{
    public class Address
    {
        public string Street { get; set; }

        public string District { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public string AdditionalInfo { get; set; }
    }
}