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
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho de Tals";
            fulano.Telefone = "(99) 9 9999-9999";
            fulano.DataNascimento = DateTime.Now.AddYears(-18);
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 100,
                Rua = "Rua das Alguma Coisa",
                Bairro = "Vila Algo",
                Cidade = "Alguma",
            };

            using (var contexto = new LojaContext())
            {
                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }

            //Promocao promocaoPascoa = MuitosParaMuitos();
            //AulaAdicionandoCompraProduto();
        }

        private static Promocao MuitosParaMuitos()
        {
            var cafe = new Produto() { Nome = "Café", Categoria = "Cafeteria", PrecoUnitario = 10.00, Unidade = "Gramas" };
            var ovoDePascoa = new Produto() { Nome = "Ovo de Páscoa", Categoria = "Doces", PrecoUnitario = 30.00, Unidade = "Gramas" };
            var chocolate = new Produto() { Nome = "Barra de Chocolate", Categoria = "Doces", PrecoUnitario = 12.00, Unidade = "Gramas" };

            var promocaoPascoa = new Promocao();
            promocaoPascoa.Descricao = "Pascoa Feliz";
            promocaoPascoa.DataInicio = DateTime.Now;
            promocaoPascoa.DataFim = DateTime.Now.AddMonths(1);

            promocaoPascoa.InserirProduto(cafe);
            promocaoPascoa.InserirProduto(ovoDePascoa);
            promocaoPascoa.InserirProduto(chocolate);
            return promocaoPascoa;
        }

        private static void AulaAdicionandoCompraProduto()
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
