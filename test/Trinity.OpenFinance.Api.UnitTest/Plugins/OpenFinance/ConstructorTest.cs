using System;
using Trinity.Openfinance.Api.Plugins.OpenFinance;
using Xunit;

namespace Trinity.OpenFinance.Api.UnitTest.Plugins.OpenFinance
{
    public class ConstructorTest: IClassFixture<Fixture> {
        private readonly Fixture _fixture;

        public ConstructorTest (Fixture fixture) {
            _fixture = fixture;
        }

        [Fact]
        public void ConstructorLoggerNull () {
            _fixture.Reset ();

            var exception = Assert.Throws<ArgumentNullException> (() => new OpenFinanceProvider(null, null));
            
            Assert.Equal ("Value cannot be null. (Parameter 'logger')", exception.Message);
            Assert.Equal ("logger", exception.ParamName);
            Assert.Null(exception.InnerException);
        }

        [Fact]
        public void ConstructorhHttpClientFactoryNull () {
            _fixture.Reset ();

            var exception = Assert.Throws<ArgumentNullException> (() => new OpenFinanceProvider(_fixture.MockLogger.Object, null));
            
            Assert.Equal ("Value cannot be null. (Parameter 'httpClientFactory')", exception.Message);
            Assert.Equal ("httpClientFactory", exception.ParamName);
            Assert.Null(exception.InnerException);
        }

        [Fact]
        public void ConstructorSuccess () {
            _fixture.Reset ();

            var openFinanceProvider = new OpenFinanceProvider (_fixture.MockLogger.Object, _fixture.MockHttpClientFactory.Object);
            
            Assert.NotNull(openFinanceProvider);
        }
    }
}