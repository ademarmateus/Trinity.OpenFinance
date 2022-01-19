using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Logging;
using Moq;
using Trinity.Openfinance.Api.Plugins.OpenFinance;

namespace Trinity.OpenFinance.Api.UnitTest.Plugins.OpenFinance 
{
    public class Fixture
    {
        public Mock<ILogger<OpenFinanceProvider>> MockLogger { get; private set; }
        
        public Mock<IHttpClientFactory> MockHttpClientFactory { get; private set; }

        public Mock<HttpMessageHandler> MockMessageHandler { get; private set; }

        public HttpClient MockClient { get; private set; }

        public OpenFinanceProvider OpenFinanceProvider { get; private set; }

        public void Reset() 
        {
            MockLogger = new Mock<ILogger<OpenFinanceProvider>>();
            MockHttpClientFactory = new Mock<IHttpClientFactory>();
            MockMessageHandler = new Mock<HttpMessageHandler>();
            MockClient = new HttpClient(MockMessageHandler.Object, false)
            {
                BaseAddress = new Uri("http://localhost")
            };
            MockHttpClientFactory.Setup(x => x.CreateClient("OpenFinanceClient"))
                .Returns(MockClient);
            OpenFinanceProvider = new OpenFinanceProvider(MockLogger.Object, MockHttpClientFactory.Object);
        }

        public HttpResponseMessage GetResponseSuccess(String result)
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = result != null ? new StringContent(result, Encoding.UTF8, "application/json"): null
            };
        }

        public HttpResponseMessage GetResponseBadRequest()
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.BadRequest
            };
        }

        public String GetOKJsonResult() 
        {
            StringBuilder result = new StringBuilder();
            result.Append("{");
            result.Append("    \"data\": { ");
            result.Append("       \"brand\": { ");
            result.Append("            \"name\": \"Banco Teste\", ");
            result.Append("         \"companies\": [ ");
            result.Append("            { ");
            result.Append("                \"name\": \"Banco Teste SA\", ");
            result.Append("                \"cnpjNumber\": \"01111111000122\", ");
            result.Append("                \"branches\": [ ");
            result.Append("                 { ");
            result.Append("                    \"identification\": { ");
            result.Append("                    \"type\": \"TESTE\", ");
            result.Append("                    \"code\": \"1\", ");
            result.Append("                    \"checkDigit\": \"N\", ");
            result.Append("                   \"name\": \"TESTE S.A CENTRO\" ");
            result.Append("                }, ");
            result.Append("                \"postalAddress\": { ");
            result.Append("                    \"address\": \"Rua Teste, 123\", ");
            result.Append("                    \"districtName\": \"Bairro Teste\", ");
            result.Append("                    \"townName\": \"Sao Paulo\", ");
            result.Append("                    \"countrySubDivision\": \"SP\", ");
            result.Append("                    \"postCode\": \"01222999\", ");
            result.Append("                    \"additionalInfo\": \"Informacao oK\" ");
            result.Append("                }, ");
            result.Append("                \"availability\": { ");
            result.Append("                    \"standards\": [ ");
            result.Append("                        { ");
            result.Append("                            \"weekday\": \"SEGUNDA_FEIRA\", ");
            result.Append("                            \"openingTime\": \"08:00:00Z\", ");
            result.Append("                            \"closingTime\": \"18:00:00Z\" ");
            result.Append("                        }, ");
            result.Append("                        { ");
            result.Append("                            \"weekday\": \"TERCA_FEIRA\", ");
            result.Append("                            \"openingTime\": \"08:00:00Z\", ");
            result.Append("                            \"closingTime\": \"18:00:00Z\" ");
            result.Append("                        }, ");
            result.Append("                        { ");
            result.Append("                            \"weekday\": \"QUARTA_FEIRA\", ");
            result.Append("                            \"openingTime\": \"08:00:00Z\", ");
            result.Append("                            \"closingTime\": \"18:00:00Z\" ");
            result.Append("                        }, ");
            result.Append("                        { ");
            result.Append("                            \"weekday\": \"QUINTA_FEIRA\", ");
            result.Append("                            \"openingTime\": \"08:00:00Z\", ");
            result.Append("                            \"closingTime\": \"18:00:00Z\" ");
            result.Append("                        }, ");
            result.Append("                        { ");
            result.Append("                            \"weekday\": \"SEXTA_FEIRA\", ");
            result.Append("                            \"openingTime\": \"08:00:00Z\", ");
            result.Append("                            \"closingTime\": \"18:00:00Z\" ");
            result.Append("                        } ");
            result.Append("                    ], ");
            result.Append("                    \"exception\": \"Exceto feriados municipais,nacionais e estaduais\" ");
            result.Append("                }, ");
            result.Append("                \"services\": [ ");
            result.Append("                    { ");
            result.Append("                        \"code\": \"OUTROS_PRODUTOS_SERVICOS\", ");
            result.Append("                        \"name\": \"OUTROS_PRODUTOS_SERVICOS\", ");
            result.Append("                        \"additionalInfo\": \"SERVICOS_ADMINISTRATIVOS\" ");
            result.Append("                    } ");
            result.Append("                ] ");
            result.Append("            } ");
            result.Append("        ] ");
            result.Append("    }, ");
            result.Append("  ] ");
            result.Append("  }");
            result.Append("  }, ");
            result.Append(" \"links\": { ");
            result.Append("     \"self\": \"https://api.banco/open-banking/channels/v1/branches?page=1&page-size=10\", ");
            result.Append("     \"first\": \"https://api.banco/open-banking/channels/v1/branches?page=1&page-size=10\", ");
            result.Append("     \"prev\": null, ");
            result.Append("     \"next\": null, ");
            result.Append("     \"last\": null ");
            result.Append(" }, ");
            result.Append(" \"meta\": { ");
            result.Append("     \"totalRecords\": 1, ");
            result.Append("     \"totalPages\": 1 ");
            result.Append(" } ");
            result.Append("} ");
            return result.ToString();
        }

        public void VerifyAll() 
        {
            MockLogger.VerifyAll();
            MockHttpClientFactory.VerifyAll();
        }

        public void VerifyNoOtherCalls()
        {
            MockHttpClientFactory.VerifyNoOtherCalls();
        }

    }
}