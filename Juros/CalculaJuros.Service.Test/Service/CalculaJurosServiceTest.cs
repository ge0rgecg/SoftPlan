using AutoFixture.Xunit2;
using CalculaJuros.Service.Interface;
using CalculaJuros.Service.Service;
using Moq;
using System;
using Xunit;

namespace CalculaJuros.Service.Test
{
    public class CalculaJurosServiceTest
    {
        private readonly Mock<ITaxaJurosProvider> _mockProvider = new Mock<ITaxaJurosProvider>();

        private ICalculaJurosService _calculaJurosService;

        public CalculaJurosServiceTest()
        {
            _calculaJurosService = new CalculaJurosService(_mockProvider.Object);
        }

        [Fact]
        public void Constructor_null()
        {
            Assert.Throws<ArgumentNullException>(
                () => new CalculaJurosService(null));
        }

        [Theory]
        [InlineAutoData(-1, -1)]
        [InlineAutoData(100, -1)]
        public void calcula_exception_test(decimal valorInicial, int meses)
        {
            Assert.Throws<Exception>(() => _calculaJurosService.calculo(valorInicial, meses));
        }

        [Theory]
        [InlineAutoData(100, 5, 105.1, 0.01)]
        public void calcula_valid_Test(decimal valorInicial, int meses, decimal valorFinal, decimal retornoObterTaxa)
        {
            _mockProvider.Setup(mock => mock.obterTaxaJuros())
                .Returns(retornoObterTaxa);

            var response = _calculaJurosService.calculo(valorInicial, meses);

            Assert.Equal(valorFinal, response);

            _mockProvider.Verify(mock => mock.obterTaxaJuros(),
                Times.Once);
        }
    }
}
