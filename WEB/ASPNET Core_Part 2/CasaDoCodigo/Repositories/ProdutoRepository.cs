using CasaDoCodigo.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto) { }

        public void SaveProdutos(List<Livro> livros)
        {
            livros
                .ForEach(livro =>
                {
                    if (!DBSet
                            .Where(produto => produto.Codigo == livro.Codigo)
                            .Any())
                    {
                        DBSet
                            .Add(new Produto(livro.Codigo, livro.Nome, livro.Preco));
                    }
                });

            contexto.SaveChanges();
        }

        public IList<Produto> GetProdutos()
        {
            return DBSet.ToList();
        }
    }
}
