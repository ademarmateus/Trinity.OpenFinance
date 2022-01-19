using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trinity.OpenFinance.Api.Domain.Interfaces;

namespace Trinity.Openfinance.Api.Plugins.OpenFinance.Extensions
{
    public static class OpenFinanceExtensions
    {
        private const string OpenFinanceHost = "OPEN_FINANCE_HOST";
        public static IServiceCollection AddOpenFinance(this IServiceCollection services, IConfiguration configuration) 
        {
            var clientOpenFinance = OpenFinanceProvider.Client;
            
            services.AddHttpClient(clientOpenFinance, (provider, client) => 
            {
                var config = provider.GetRequiredService<IConfiguration>();
                client.BaseAddress = new Uri(config.GetValue<string>(OpenFinanceHost));
            });
            
            services.AddTransient<IGetBranches, OpenFinanceProvider>();
            return services;
        }
    }
}