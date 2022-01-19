using System.Threading.Tasks;
using Moq;
using Xunit;

namespace Trinity.OpenFinance.Api.UnitTest.Domain.Handlers.FindBranchesHandlerTest
{
    public class HandleTest: IClassFixture<Fixture> 
    {
        private readonly Fixture _fixture;

        public HandleTest(Fixture fixture) 
        {
            _fixture = fixture;
        }

        [Fact]
        public async Task HandleReturnSucess() 
        {
            _fixture.Reset();
        
            _fixture.MockGetBranches.Setup(exp => exp.GetAllBranchesAsync(1, 20)).ReturnsAsync(_fixture.DefaultBranchData);

            var result = await _fixture.FindBranchesHandler.Handle(_fixture.DefaultFindBranchesRequest, _fixture.DefaultCancellationToken);

            Assert.NotNull(result);
            Assert.Equal("Banco Teste", result.Brand.Name);
            Assert.Equal(1,result.Meta.TotalPages);
            Assert.Equal(1, result.Meta.TotalRecords);
            Assert.Equal("Banco Teste SA", result.Brand.Companies[0].Name);
            Assert.Equal("Banco Teste SA", result.Brand.Companies[0].Branches[0].Name);
            Assert.Equal("Rua Teste, 123", result.Brand.Companies[0].Branches[0].Address.Street);
        }
        
    }
}