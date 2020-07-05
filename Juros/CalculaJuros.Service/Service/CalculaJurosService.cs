using CalculaJuros.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace CalculaJuros.Service.Service
{
    public class CalculaJurosService : ICalculaJurosService
    {
        public decimal calculo(decimal valorInicial, int tempo)
        {
            var isValid = validarCalculo(valorInicial, tempo);

            if (!string.IsNullOrWhiteSpace(isValid))
            {
                throw new Exception(isValid);
            }

            throw new NotImplementedException();
        }

        public string gitURL()
        {
            throw new NotImplementedException();
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
