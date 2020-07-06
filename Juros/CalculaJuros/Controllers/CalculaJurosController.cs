using CalculaJuros.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;

namespace CalculaJuros.API.Controllers
{
    /// <summary>
    /// Controller responsavel pelo calculo de juros e por mostrar o repositorio Git com o código.
    /// </summary>
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
            _calculaJurosService = calculaJurosService == null ? throw new ArgumentNullException("calculaJurosService") : calculaJurosService;
            _calculaJurosSettings = options?.Value == null ? throw new ArgumentNullException("options") : options.Value;
        }

        /// <summary>
        /// Calculo o valor do juros.
        /// </summary>
        /// <param name="valorInicial">Valor inicial</param>
        /// <param name="meses">Meses para calculo</param>
        /// <returns>Valor final, após executar os calculos de juros.</returns>
        [HttpGet("{valorInicial}/{meses}")]
        public decimal Get(decimal valorInicial, int meses)
        {
            return _calculaJurosService.calculo(valorInicial, meses);
        }

        /// <summary>
        /// Mostro o código.
        /// </summary>
        /// <returns>Retorno URL com o caminho do repositorio GIT.</returns>
        [HttpGet("/showmethecode")]
        public string ShowMeTheCode()
        {
            return _calculaJurosSettings.GitUrl;
        }

    }
}
