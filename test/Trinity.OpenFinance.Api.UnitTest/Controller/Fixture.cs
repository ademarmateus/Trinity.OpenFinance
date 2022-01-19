using System.Collections.Generic;
using System.Threading;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Trinity.OpenFinance.Api.Controllers;
using Trinity.OpenFinance.Api.Domain.Entities;
using Trinity.OpenFinance.Api.Domain.Queries.Requests;

namespace Trinity.OpenFinance.Api.UnitTest.Controller {
    public class Fixture {
        public Mock<IMediator> MockMediator { get; private set; }

        public Mock<ILogger<BranchController>> MockLogger { get; private set; }

        public BranchController BranchController { get; private set; }

        public CancellationToken DefaultCancellationToken => CancellationToken.None;

        public void Reset () {
            MockMediator = new Mock<IMediator> ();
            MockLogger = new Mock<ILogger<BranchController>> ();
            BranchController = new BranchController (MockLogger.Object, MockMediator.Object);
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