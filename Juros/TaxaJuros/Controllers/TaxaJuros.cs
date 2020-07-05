using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TaxaJuros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxaJuros : ControllerBase
    {
        // GET: api/<taxaJuros>
        [HttpGet]
        //[Route("taxaJuros")]
        public decimal Get()
        {
            return 0.01M;
        }
    }
}
