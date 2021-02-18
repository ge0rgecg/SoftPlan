using System.Threading.Tasks;

namespace CalculaJuros.Service.Interface
{
    public interface ITaxaJurosProvider
    {
        Task<decimal> obterTaxaJuros();
    }
}
