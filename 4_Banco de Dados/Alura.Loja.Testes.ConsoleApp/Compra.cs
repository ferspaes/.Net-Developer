using System;
using System.ComponentModel.DataAnnotations;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Compra
    {
        public int Id { get; protected set; }
        public int Quantidade { get; internal set; }
        public int ProdutoId { get; internal set; }
        public Produto Produto { get; internal set; }
        public double Valor { get; internal set; }
        public DateTime Data { get; internal set; }

        public override string ToString()
        {
            return $"{Produto.Nome} {Quantidade} X R${Produto.PrecoUnitario} = R${Valor}";
        }
    }
}