using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroController
    {
        public string Adicionar(Livro livro)
        {
            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);

            return "Livro Adicionado com sucesso!";
        }
    }
}
