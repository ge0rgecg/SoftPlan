using CalculaJuros.Service.Interface;
using System;

namespace CalculaJuros.Service.Service
{
    public class CalculaJurosService : ICalculaJurosService
    {
        private ITaxaJurosProvider _taxaJurosProvider;

        public CalculaJurosService(ITaxaJurosProvider taxaJurosProvider)
        {
            _taxaJurosProvider = taxaJurosProvider == null ? throw new ArgumentNullException("taxaJurosProvider") : taxaJurosProvider;
        }

        public decimal calculo(decimal valorInicial, int tempo)
        {
            var isValid = validarCalculo(valorInicial, tempo);

            if (!string.IsNullOrWhiteSpace(isValid))
            {
                throw new Exception(isValid);
            }

            var juros = _taxaJurosProvider.obterTaxaJuros();

            var valorFinal = valorInicial * (Decimal)Math.Pow((double)(1 + juros), tempo);

            return decimal.Round(valorFinal, 2);
        }

        private string validarCalculo(decimal valorInicial, int tempo)
        {
            if(tempo < 0)
            {
                return "O parametro Tempo é inválido.";
            }

            if(valorInicial < 0)
            {
                return "O parametro Valor Inicial é inválido.";
            }

            return string.Empty;
        }
    }
}
