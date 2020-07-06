using AutoFixture.Xunit2;
using CalculaJuros.API.Controllers;
using CalculaJuros.Service.Interface;
using Microsoft.Extensions.Options;
using Moq;
using System;
using Xunit;

namespace CalculaJuros.API.Test
{
    public class CalculaJurosControllerTest
    {
        private readonly Mock<IOptions<CalculaJurosApiSettings>> _mockOptions =
            new Mock<IOptions<CalculaJurosApiSettings>>();

        private readonly Mock<ICalculaJurosService> _mockService = new Mock<ICalculaJurosService>();

        private CalculaJurosController controller;

        [Fact]
        public void Constructor_null()
        {
            Assert.Throws<ArgumentNullException>(
                () => new CalculaJurosController(_mockService.Object, null)
            );

            Assert.Throws<ArgumentNullException>(
                () => new CalculaJurosController(null, _mockOptions.Object)
            );
        }

        public CalculaJurosControllerTest()
        {
            _mockOptions.Setup(mock => mock.Value).Returns(new CalculaJurosApiSettings { GitUrl = "https://localhost:5001/api/TaxaJuros" });

            controller = new CalculaJurosController(_mockService.Object, _mockOptions.Object);
        }

        [Fact]
        public void Show_Me_The_Code_Test()
        {
            var response = controller.ShowMeTheCode();

            Assert.IsType<string>(response);
            Assert.Equal("https://localhost:5001/api/TaxaJuros", response);
        }

        [Theory]
        [AutoData]
        public void Get_Test(decimal valorInicial, int meses, decimal retorno)
        {
            _mockService.Setup(mock =>
                mock.calculo(It.IsAny<decimal>(), It.IsAny<int>()))
            .Returns(retorno);
                
            var response = controller.Get(valorInicial, meses);

            Assert.IsType<decimal>(response);
            Assert.Equal(retorno, response);

            _mockService.Verify(
                mock => mock.calculo(It.IsAny<decimal>(), It.IsAny<int>()),
                Times.Once);
        }
    }
}
