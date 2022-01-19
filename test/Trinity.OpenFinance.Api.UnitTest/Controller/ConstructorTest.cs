using System;
using Trinity.OpenFinance.Api.Controllers;
using Xunit;

namespace Trinity.OpenFinance.Api.UnitTest.Controller {
    public class ConstructorTest : IClassFixture<Fixture> {
        private readonly Fixture _fixture;

        public ConstructorTest (Fixture fixture) {
            _fixture = fixture;
        }

        [Fact]
        public void ConstructorLoggerNull () {
            _fixture.Reset ();

            var exception = Assert.Throws<ArgumentNullException> (() => new BranchController (null, null));
            
            Assert.Equal ("Value cannot be null. (Parameter 'logger')", exception.Message);
            Assert.Equal ("logger", exception.ParamName);
            Assert.Null(exception.InnerException);
        }

        [Fact]
        public void ConstructorMediatorNull () {
            _fixture.Reset ();

            var exception = Assert.Throws<ArgumentNullException> (() => new BranchController (_fixture.MockLogger.Object, null));
            
            Assert.Equal ("Value cannot be null. (Parameter 'mediator')", exception.Message);
            Assert.Equal ("mediator", exception.ParamName);
            Assert.Null(exception.InnerException);
        }

        [Fact]
        public void ConstructorSuccess () {
            _fixture.Reset ();

            var branchController = new BranchController (_fixture.MockLogger.Object, _fixture.MockMediator.Object);
            
            Assert.NotNull(branchController);
        }

    }
}