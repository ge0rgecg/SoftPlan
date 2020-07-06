using System;
using TaxaJuros.Controllers;
using Xunit;

namespace TaxaJuros.API.Test.Controllers
{
    public class TaxaJurosControllerTest
    {
        [Fact]
        public void Get_Taxa_Juros_Test()
        {
            var controller = new TaxaJurosController();

            var response = controller.Get();

            Assert.IsType<decimal>(response);
            Assert.Equal(0.01M, response);
        }
    }
}
