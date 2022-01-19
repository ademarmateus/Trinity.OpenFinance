using System.Collections.Generic;

namespace Trinity.OpenFinance.Api.Domain.Entities
{
    public class Company
    {
        public string Name { get; set; }

        public string Cnpj { get; set; }

        public List<Branch> Branches { get; set; }
    }
}