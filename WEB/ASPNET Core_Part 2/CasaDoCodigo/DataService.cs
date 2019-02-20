using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;

namespace CasaDoCodigo
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;
        private readonly ILivro livro;

        public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository, ILivro livro)
        {
            this.contexto = contexto;
            this.produtoRepository = produtoRepository;
            this.livro = livro;
        }

        public void InicializarDB()
        {
            contexto.Database.EnsureCreated();

            var livros = livro.GetLivros();
            produtoRepository.SaveProdutos(livros);
        }


    }
}
