using CalculaJuros.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace CalculaJuros.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : ControllerBase
    {
        private readonly ICalculaJurosService _calculaJurosService;

        private CalculaJurosApiSettings _calculaJurosSettings;

        public CalculaJurosController(
            ICalculaJurosService calculaJurosService,
            IOptions<CalculaJurosApiSettings> options)
        {
            _calculaJurosService = calculaJurosService;
            _calculaJurosSettings = options.Value;
        }

        // GET: api/<CalculaJurosController>
        [HttpGet("{valorInicial}/{meses}")]
        public decimal Get(decimal valorInicial, int meses)
        {
            return _calculaJurosService.calculo(valorInicial, meses);
        }

        // GET api/<CalculaJurosController>/5
        [HttpGet("/showmethecode")]
        public string ShowMeTheCode()
        {
            return _calculaJurosSettings.GitUrl;
        }

    }
}
