using CalculaJuros.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CalculaJuros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        public readonly ICalculaJurosService _calculaJurosService;

        public CalculaJurosController(ICalculaJurosService calculaJurosService)
        {
            _calculaJurosService = calculaJurosService;
        }

        // GET: api/<CalculaJurosController>
        [HttpGet("{valorInicial}?{meses}")]
        public decimal Get(decimal valorInicial, int meses)
        {
            return _calculaJurosService.calculo(valorInicial, meses);
        }

        // GET api/<CalculaJurosController>/5
        [HttpGet("/showmethecode")]
        public string ShowMeTheCode()
        {
            return _calculaJurosService.gitURL();
        }

    }
}
