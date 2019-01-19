using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var paoFrances = new Produto();
            paoFrances.Categoria = "Padaria";
            paoFrances.Nome = "Pão Francês";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade = "Unidade";

            var compra = new Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Valor = paoFrances.PrecoUnitario * compra.Quantidade;
            compra.Data = DateTime.Now;

            using (var contexto = new LojaContext())
            {
                contexto.Compras.Add(compra);
                //contexto.SaveChanges();
            }
        }
    }
}
