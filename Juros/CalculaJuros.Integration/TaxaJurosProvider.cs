using CalculaJuros.Service.Interface;
using System;
using System.Net;
using System.Net.Http;

namespace CalculaJuros.Integration
{
    public class TaxaJurosProvider : ITaxaJurosProvider
    {
        public decimal obterTaxaJuros()
        {
            using (var client = new HttpClient(new HttpClientHandler()
            {
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            }))
            {

                client.BaseAddress = new Uri("https://localhost:55771/");

                HttpResponseMessage response = client.GetAsync("api/TaxaJuros").Result;
                response.EnsureSuccessStatusCode();
                string result = response.Content.ReadAsStringAsync().Result;
                
                
                return Decimal.Parse(result);
            }
        }
    }
}
