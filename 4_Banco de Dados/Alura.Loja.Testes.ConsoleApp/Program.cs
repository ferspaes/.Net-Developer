using Microsoft.EntityFrameworkCore;
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
            using (var contexto = new LojaContext())
            {
                var produtosCompras = contexto.Produtos
                    .Include(produto => produto.Compras)
                    .Where(compra => compra.Id.Equals(40))
                    .FirstOrDefault();

                Console.WriteLine(produtosCompras);
                produtosCompras.Compras.ForEach(compra => Console.WriteLine(compra));
            }

            //SelectNaPromocao();
            //AdicionaNovaPromocao();
            //Promocao promocaoPascoa = MuitosParaMuitos();
            //AulaAdicionandoCompraProduto();
            //InsertCliente();

            Console.Read();
        }

        private static void SelectNaPromocao()
        {
            using (var contextoSelect = new LojaContext())
            {
                var promocao = contextoSelect.Promocoes
                    .Include(promocoes => promocoes.Produtos)
                    .ThenInclude(produtoPromocao => produtoPromocao.Produto)
                    .FirstOrDefault();

                promocao.Produtos.ForEach(promocaoProduto => Console.WriteLine(promocaoProduto.Produto));
            }
        }

        private static void AdicionaNovaPromocao()
        {
            var nescau = new Produto();
            nescau.Nome = "Nescau";
            nescau.PrecoUnitario = 9.99;
            nescau.Unidade = "Gramas";
            nescau.Categoria = "Bebidas";

            var vinho = new Produto();
            nescau.Nome = "Vinho";
            nescau.PrecoUnitario = 15.99;
            nescau.Unidade = "Litros";
            nescau.Categoria = "Bebidas";

            var leite = new Produto();
            nescau.Nome = "Leite";
            nescau.PrecoUnitario = 2.99;
            nescau.Unidade = "Litros";
            nescau.Categoria = "Bebidas";

            using (var contextoProdutosNovos = new LojaContext())
            {
                contextoProdutosNovos.Produtos.Add(nescau);
                contextoProdutosNovos.Produtos.Add(vinho);
                contextoProdutosNovos.Produtos.Add(leite);
                contextoProdutosNovos.SaveChanges();
            }

            var promocaoPrimavera = new Promocao();
            promocaoPrimavera.DataInicio = new DateTime(2018, 9, 1);
            promocaoPrimavera.DataFim = new DateTime(2018, 9, 30);
            promocaoPrimavera.Descricao = "Promoção Primavera";

            using (var contexto = new LojaContext())
            {
                var produtosPromocao = contexto.Produtos
                                                .Where(produto => produto.Categoria.Equals("Bebidas"))
                                                .ToList();

                produtosPromocao.ForEach(produto => promocaoPrimavera.InserirProduto(produto));

                contexto.SaveChanges();
            }
        }

        private static void InsertCliente()
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
                contexto.SaveChanges();
            }
        }
    }
}
