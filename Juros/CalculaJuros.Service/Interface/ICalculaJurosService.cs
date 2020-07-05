namespace CalculaJuros.Service.Interface
{
    public interface ICalculaJurosService
    {
        decimal calculo(decimal valorInicial, int tempo);

        string gitURL();
    }
}
