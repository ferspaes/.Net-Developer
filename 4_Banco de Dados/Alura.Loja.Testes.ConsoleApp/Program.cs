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
            GravarUsandoEntity();
            ConsultarUsandoEntity();
            ExcluirProdutos();
            GravarUsandoEntity();
            AtualizarProdutos();

            Console.Read();
        }

        private static void AtualizarProdutos()
        {
            ConsultarUsandoEntity();

            using (var repo = new ProdutoDAOEntity())
            {
                var produto = repo.Produtos().First();

                produto.Nome = "Harry Potter e as Relíquias da Morte";
                repo.Atualizar(produto);
            }

            ConsultarUsandoEntity();
        }

        private static void ExcluirProdutos()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                repo.Produtos().ForEach(produto => repo.Remover(produto));
            }

            ConsultarUsandoEntity();
        }

        private static void ConsultarUsandoEntity()
        {
            using (var repo = new ProdutoDAOEntity())
            {
                repo.Produtos().ForEach(produto => Console.WriteLine(produto));
            }
        }

        private static void GravarUsandoEntity()
        {
            Produto p = new Produto();
            p.Nome = "Fantastic Beasts and Where to Find Them";
            p.Categoria = "Livros";
            p.Preco = 48.50;

            using (var contexto = new ProdutoDAOEntity())
            {
                contexto.Adicionar(p);
            }
        }

        private static void GravarUsandoAdoNet()
        {
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            using (var repo = new ProdutoDAO())
            {
                repo.Adicionar(p);
            }
        }
    }
}
