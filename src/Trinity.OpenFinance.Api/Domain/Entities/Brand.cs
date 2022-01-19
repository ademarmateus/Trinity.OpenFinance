using System.Collections.Generic;

namespace Trinity.OpenFinance.Api.Domain.Entities
{
    public class Brand
    {
        public string Name { get; set; }

        public List<Company> Companies { get; set; }
    }
}