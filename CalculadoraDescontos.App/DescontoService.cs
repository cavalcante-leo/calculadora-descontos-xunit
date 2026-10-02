using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculadoraDescontos.App
{
    public class DescontoService
    {
        private int desconto = 10;
        public string ObterCategoriaCliente(int totalCompras)
        {
            if (totalCompras < 5)
            { return "BRONZE"; }
            else if (totalCompras <= 10)
            { return "PRATA"; }
            else
            { return "OURO"; }
        }
        public int CalcularDescontoPorPercentual(int valorOriginal, int percentualDesconto)
        {    
            return valorOriginal - (valorOriginal * percentualDesconto / 100);
        }
        public bool isValidoParaCupom(int idade, bool primeiraCompra)
        {
            return idade >= 18 || primeiraCompra;
        }
    }
}