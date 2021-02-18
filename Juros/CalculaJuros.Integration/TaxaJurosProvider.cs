using CalculaJuros.Service.Interface;
using Microsoft.Extensions.Options;
using Polly;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace CalculaJuros.Integration
{
    public class TaxaJurosProvider : ITaxaJurosProvider
    {
        private CalculaJurosIntegrationSettings _calculaJurosSettings;
        private readonly HttpClient httpClient;
        private int maxRetry = 5;
        
        public TaxaJurosProvider(IOptions<CalculaJurosIntegrationSettings> options, IHttpClientFactory httpClientFactory)
        {
            _calculaJurosSettings = options?.Value == null ? throw new ArgumentNullException("options") : options.Value;
            httpClient = httpClientFactory.CreateClient("Integrations");
        }

        public async Task<decimal> obterTaxaJuros()
        {
            var retryPolicy = Policy.Handle<HttpRequestException>()
                .WaitAndRetryAsync(maxRetry, i => TimeSpan.FromMinutes(Math.Pow(2, i)));

            return await retryPolicy.ExecuteAsync<decimal>(async () =>
            {
                var response = await httpClient.GetAsync("TaxaJuros");

                response.EnsureSuccessStatusCode();

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return Convert.ToDecimal(response.Content.ReadAsStringAsync().Result);
                }
                return 0;
            });
        }
    }
}