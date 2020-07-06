using Microsoft.Extensions.Options;
using Moq;
using System;
using Xunit;

namespace CalculaJuros.Integration.Test
{
    public class TaxaJurosProviderTest
    {
        private readonly Mock<IOptions<CalculaJurosIntegrationSettings>> _mockOptions = new Mock<IOptions<CalculaJurosIntegrationSettings>>();

        private TaxaJurosProvider _provider;

        [Fact]
        public void Constructor_null()
        {
            Assert.Throws<ArgumentNullException>(
                () => new TaxaJurosProvider(null));
        }

        public TaxaJurosProviderTest()
        {
            _mockOptions.Setup(mock => mock.Value).Returns(new CalculaJurosIntegrationSettings
            {
                urlTaxaJuros = "urlTaxaJuros"
            });

            _provider = new TaxaJurosProvider(_mockOptions.Object);
        }
    }
}
