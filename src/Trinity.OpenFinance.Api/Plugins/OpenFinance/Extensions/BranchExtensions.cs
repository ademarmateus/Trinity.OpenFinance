using System.Linq;
using Trinity.Openfinance.Api.Plugins.OpenFinance.Dto;
using Trinity.OpenFinance.Api.Domain.Entities;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Extensions {
    public static class BranchExtensions {
        public static BranchData ToBranchData (this BranchDataDto branchDataDto) {
            BranchData branchData = new BranchData ();
            if (branchDataDto != null) {
                if ((branchDataDto.Data != null) &&
                (branchDataDto.Data.Brand != null)) {
                branchData.Brand = new Brand {
                Name = branchDataDto.Data.Brand.Name,
                Companies = branchDataDto.Data.Brand?.Companies?.Select (company => company.ToCompany ()).ToList ()
                    };
                }

                if ((branchDataDto.Meta != null)) {
                    branchData.Meta = new Meta {
                    TotalPages = branchDataDto.Meta.TotalPages,
                    TotalRecords = branchDataDto.Meta.TotalRecords
                    };
                }

            }
            return branchData;
        }

        public static Company ToCompany (this CompanyDto companyDto) {

            return new Company {
                Name = companyDto.Name,
                    Cnpj = companyDto.CnpjNumber,
                    Branches = companyDto?.Branches?.Select (branch => branch.ToBranch()).ToList()
            };
        }

        public static Branch ToBranch(this BranchDto branchDto) {
            Branch branch = new Branch ();
            branch.Name = branchDto.Identification?.Name;
            branch.Address = new Address ();
            branch.Address.Street = branchDto.PostalAddress?.Address;
            branch.Address.District = branchDto.PostalAddress?.DistrictName;
            branch.Address.State = branchDto.PostalAddress?.CountrySubDivision;
            branch.Address.City = branchDto.PostalAddress?.TownName;
            branch.Address.ZipCode = branchDto.PostalAddress?.PostCode;
            branch.Address.AdditionalInfo = branchDto.PostalAddress?.AdditionalInfo;
            return branch;
        }
    }
}