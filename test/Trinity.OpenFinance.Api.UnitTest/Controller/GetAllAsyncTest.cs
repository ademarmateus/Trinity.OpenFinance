using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Trinity.OpenFinance.Api.Domain.Entities;
using Trinity.OpenFinance.Api.Domain.Queries.Requests;
using Xunit;

namespace Trinity.OpenFinance.Api.UnitTest.Controller
{
    public class GetAllAsyncTest: IClassFixture<Fixture> 
    {
        private readonly Fixture _fixture;

        public GetAllAsyncTest(Fixture fixture) 
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetAllAsyncTestReturnOk() 
        {
            _fixture.Reset();

            _fixture.MockMediator.Setup(x => x.Send(It.IsAny<FindBranchesRequest>(), _fixture.DefaultCancellationToken))
                .ReturnsAsync( _fixture.DefaultBranchData);

            var result = await _fixture.BranchController.GetAllAsync(_fixture.DefaultFindBranchesRequest);

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);
            
        }    
    }
}