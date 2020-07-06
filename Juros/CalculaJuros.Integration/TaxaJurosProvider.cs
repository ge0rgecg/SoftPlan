using CalculaJuros.Service.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Http;

namespace CalculaJuros.Integration
{
    public class TaxaJurosProvider : ITaxaJurosProvider
    {
        private CalculaJurosIntegrationSettings _calculaJurosSettings;

        public TaxaJurosProvider(IOptions<CalculaJurosIntegrationSettings> options)
        {
            _calculaJurosSettings = options?.Value == null ? throw new ArgumentNullException("options") : options.Value;
        }

        public decimal obterTaxaJuros()
        {
            using (var client = new HttpClient(new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            }))
            {
                client.BaseAddress = new Uri(_calculaJurosSettings.urlTaxaJuros);

                HttpResponseMessage response = client.GetAsync("").Result;
                response.EnsureSuccessStatusCode();
                var result = response.Content.ReadAsStringAsync().Result;

                return Convert.ToDecimal(result.Replace('.', ','));
            }
        }
    }
}
