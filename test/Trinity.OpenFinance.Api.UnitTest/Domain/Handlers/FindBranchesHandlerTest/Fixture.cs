using System.Collections.Generic;
using System.Threading;
using Moq;
using Trinity.OpenFinance.Api.Domain.Entities;
using Trinity.OpenFinance.Api.Domain.Handlers;
using Trinity.OpenFinance.Api.Domain.Interfaces;
using Trinity.OpenFinance.Api.Domain.Queries.Requests;

namespace Trinity.OpenFinance.Api.UnitTest.Domain.Handlers.FindBranchesHandlerTest
{
    public class Fixture
    {
        public Mock<IGetBranches> MockGetBranches { get; private set; }

        public FindBranchesHandler FindBranchesHandler { get; private set; }

        public CancellationToken DefaultCancellationToken => CancellationToken.None;

        public void Reset() 
        {
            MockGetBranches = new Mock<IGetBranches>();
            FindBranchesHandler = new FindBranchesHandler(MockGetBranches.Object);
        }

        public void VerifyAll() 
        {
            MockGetBranches.VerifyAll();
        }

        public void VerifyNoOthersCalls() 
        {
            MockGetBranches.VerifyNoOtherCalls();
        }
        
        public FindBranchesRequest DefaultFindBranchesRequest = new FindBranchesRequest 
        {
            Page = 1,
            Size = 20
        };

        public BranchData DefaultBranchData => new BranchData 
        {
            Meta = new Meta 
            {
                TotalPages = 1,
                TotalRecords = 1
            },
            Brand = new Brand 
            {
                Name = "Banco Teste",
                Companies = new List<Company> {
                    new Company {
                        Name = "Banco Teste SA",
                        Cnpj = "01111111000122",
                        Branches = new List<Branch> 
                        {
                            new Branch 
                            {
                                Name = "Banco Teste SA",
                                Address = new Address 
                                {
                                    Street = "Rua Teste, 123",
                                    City = "Sao Paulo",
                                    State = "SP",
                                    District = "Bairro Teste",
                                    ZipCode = "01222999",
                                    AdditionalInfo = "Informacao oK"
                                }
                            }
                        }
                    }
                }
            }
        };

        
        
    }
}