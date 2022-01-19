using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Protected;
using Trinity.Openfinance.Api.Plugins.OpenFinance.Exceptions;
using Xunit;

namespace Trinity.OpenFinance.Api.UnitTest.Plugins.OpenFinance {
    public class GetAllBranchesAsyncTest : IClassFixture<Fixture> {
        private readonly Fixture _fixture;

        public GetAllBranchesAsyncTest (Fixture fixture) {
            _fixture = fixture;
        }

        [Fact]
        public async Task GetAllBranchesAsyncTrownOpenFinanceProvider () {
            _fixture.Reset ();

            _fixture.MockMessageHandler.Protected ()
                .Setup<Task<HttpResponseMessage>> ("SendAsync",
                    ItExpr.Is<HttpRequestMessage> (x =>
                        x.RequestUri.AbsolutePath.Contains ("/open-banking/channels/v1/branches") &&
                        x.Method == HttpMethod.Get &&
                        x.Content == null),
                    ItExpr.IsAny<CancellationToken> ())
                .ThrowsAsync (new Exception ("Erro ao consultar"));

            var exception = await Assert.ThrowsAsync<OpenFinanceProviderException> (() =>
                _fixture.OpenFinanceProvider.GetAllBranchesAsync (1, 10));

            Assert.Equal ("Erro ao consultar as filiais do banco", exception.Message);

            _fixture.VerifyAll ();
            _fixture.VerifyNoOtherCalls ();
        }

        [Fact]
        public async Task GetAllBranchesReturnNull () {
            _fixture.Reset ();

            _fixture.MockMessageHandler.Protected ()
                .Setup<Task<HttpResponseMessage>> ("SendAsync",
                    ItExpr.Is<HttpRequestMessage> (x =>
                        x.RequestUri.AbsolutePath.Contains ("/open-banking/channels/v1/branches") &&
                        x.Method == HttpMethod.Get &&
                        x.Content == null),
                    ItExpr.IsAny<CancellationToken> ())
                .ReturnsAsync (_fixture.GetResponseSuccess (null));

            var result = await _fixture.OpenFinanceProvider.GetAllBranchesAsync (1, 10);

            Assert.Null (result);

            _fixture.VerifyAll ();
            _fixture.VerifyNoOtherCalls ();
        }

        [Fact]
        public async Task GetAllBranchesReturnOK () {
            _fixture.Reset ();

            _fixture.MockMessageHandler.Protected ()
                .Setup<Task<HttpResponseMessage>> ("SendAsync",
                    ItExpr.Is<HttpRequestMessage> (x =>
                        x.RequestUri.AbsolutePath.Contains ("/open-banking/channels/v1/branches") &&
                        x.Method == HttpMethod.Get &&
                        x.Content == null),
                    ItExpr.IsAny<CancellationToken> ())
                .ReturnsAsync (_fixture.GetResponseSuccess (_fixture.GetOKJsonResult ()));

            var result = await _fixture.OpenFinanceProvider.GetAllBranchesAsync (1, 10);

            Assert.NotNull (result);
            Assert.Equal ("Banco Teste", result.Brand.Name);
            Assert.Equal (1, result.Meta.TotalPages);
            Assert.Equal (1, result.Meta.TotalRecords);
            Assert.Equal ("Banco Teste SA", result.Brand.Companies[0].Name);
            Assert.Equal ("TESTE S.A CENTRO", result.Brand.Companies[0].Branches[0].Name);
            Assert.Equal ("Rua Teste, 123", result.Brand.Companies[0].Branches[0].Address.Street);

            _fixture.VerifyAll ();
            _fixture.VerifyNoOtherCalls ();
        }

        [Fact]
        public async Task GetAllBranchesReturnBadRequest () {
            _fixture.Reset ();

            _fixture.MockMessageHandler.Protected ()
                .Setup<Task<HttpResponseMessage>> ("SendAsync",
                    ItExpr.Is<HttpRequestMessage> (x =>
                        x.RequestUri.AbsolutePath.Contains ("/open-banking/channels/v1/branches") &&
                        x.Method == HttpMethod.Get &&
                        x.Content == null),
                    ItExpr.IsAny<CancellationToken> ())
                .ReturnsAsync (_fixture.GetResponseBadRequest());

                        var exception = await Assert.ThrowsAsync<OpenFinanceProviderException> (() =>
                _fixture.OpenFinanceProvider.GetAllBranchesAsync (1, 10));

            Assert.Equal ("Erro ao consultar as filiais do banco - BadRequest", exception.Message);

            _fixture.VerifyAll ();
            _fixture.VerifyNoOtherCalls ();

        }

    }
}