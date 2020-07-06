using Microsoft.AspNetCore.Mvc;

namespace TaxaJuros.Controllers
{
    /// <summary>
    /// Controller responsavel por informar a Taxa de Juros.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        /// <summary>
        /// Informo a taxa de Juros.
        /// </summary>
        /// <returns>Valor em decimal da taxa de Juros.</returns>
        [HttpGet]
        public decimal Get()
        {
            return 0.01M;
        }
    }
}
