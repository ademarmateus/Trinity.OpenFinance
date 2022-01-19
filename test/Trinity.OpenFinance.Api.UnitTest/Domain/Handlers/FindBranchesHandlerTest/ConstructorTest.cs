using System;
using Trinity.OpenFinance.Api.Domain.Handlers;
using Xunit;

namespace Trinity.OpenFinance.Api.UnitTest.Domain.Handlers.FindBranchesHandlerTest
{
    public class ConstructorTest: IClassFixture<Fixture> {
        private readonly Fixture _fixture;

        public ConstructorTest (Fixture fixture) {
            _fixture = fixture;
        }

        [Fact]
        public void ConstructorGetBranchesNull () {
            _fixture.Reset ();

            var exception = Assert.Throws<ArgumentNullException> (() => new FindBranchesHandler (null));
            
            Assert.Equal ("Value cannot be null. (Parameter 'getBranches')", exception.Message);
            Assert.Equal ("getBranches", exception.ParamName);
            Assert.Null(exception.InnerException);
        }

        [Fact]
        public void ConstructorSuccess () {
            _fixture.Reset ();

            var branchController = new FindBranchesHandler (_fixture.MockGetBranches.Object);
            
            Assert.NotNull(branchController);
        }
        
    }
}