using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Trinity.Openfinance.Api.Plugins.OpenFinance.Dto;
using Trinity.Openfinance.Api.Plugins.OpenFinance.Exceptions;
using Trinity.Openfinance.Api.Plugins.OpenFinance.Extensions;
using Trinity.OpenFinance.Api.Domain.Entities;
using Trinity.OpenFinance.Api.Domain.Interfaces;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance
{
    public class OpenFinanceProvider : IGetBranches
    {

        public const string Client = "OpenFinanceClient";

        private readonly ILogger<OpenFinanceProvider> _logger;

        private readonly IHttpClientFactory _httpClientFactory;

        public OpenFinanceProvider(ILogger<OpenFinanceProvider> logger, IHttpClientFactory httpClientFactory) 
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _httpClientFactory = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));
        }
        
        public async Task<BranchData> GetAllBranchesAsync(int? page, int? pageSize)
        {
            
            using var client = _httpClientFactory.CreateClient(Client);
            
            string path = $"open-banking/channels/v1/branches";

            if ((page.HasValue) && (pageSize.HasValue)) 
            {
                path += $"?page={page}&page-size={pageSize}";
            }
            

            _logger.LogDebug("Chamada no path", path);

            HttpResponseMessage reponseMessage;
            try 
            {
                reponseMessage = await client.GetAsync(path);
            }
            catch (Exception ex) 
            {
                _logger.LogError($"Erro ao consultar as filiais do banco: {ex.Message}");
                throw new OpenFinanceProviderException("Erro ao consultar as filiais do banco", ex);
            }

            if (reponseMessage.IsSuccessStatusCode) 
            {
                var responseBody = await reponseMessage.Content.ReadAsStringAsync();
                var branches = JsonConvert.DeserializeObject<BranchDataDto>(responseBody);
                return branches?.ToBranchData();
            } else 
            {
                throw new OpenFinanceProviderException($"Erro ao consultar as filiais do banco - {reponseMessage.StatusCode}");
            }
        }
    }
}