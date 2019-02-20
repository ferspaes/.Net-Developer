using System.Collections.Generic;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Produto
    {
        public int Id { get; protected set; }
        public string Nome { get; internal set; }
        public string Categoria { get; internal set; }
        public double PrecoUnitario { get; internal set; }
        public string Unidade { get; internal set; }
        public List<PromocaoProduto> Promocoes { get; set; }
        public List<Compra> Compras { get; set; }


        public override string ToString()
        {
            return $"Nome: {Nome}, Categoria: {Categoria}, Preço: {PrecoUnitario}";
        }
    }
}