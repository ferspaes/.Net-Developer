using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CadastroLogica
    {
        public static Task TrataFormulario(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = context.Request.Form["titulo"].First(),
                Autor = context.Request.Form["autor"].First()
            };

            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);

            return context.Response.WriteAsync("Livro Adicionado com sucesso!");
        }

        public static Task AdicionarLivros(HttpContext context)
        {
            var livro = new Livro()
            {
                Titulo = Convert.ToString(context.GetRouteValue("nome")),
                Autor = Convert.ToString(context.GetRouteValue("autor"))
            };

            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);

            return context.Response.WriteAsync("Livro Adicionado com sucesso!");
        }
    }
}
