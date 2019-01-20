using System;
using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Promocao
    {
        public Promocao()
        {
            Produtos = new List<PromocaoProduto>();
        }

        public int Id { get; set; }
        public string Descricao { get; internal set; }
        public DateTime DataInicio { get; internal set; }
        public DateTime DataFim { get; internal set; }
        public List<PromocaoProduto> Produtos { get; internal set; }

        internal void InserirProduto(Produto produto)
        {
            Produtos.Add(new PromocaoProduto() { Produto = produto });
        }
    }
}