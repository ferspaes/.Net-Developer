using Alura.ListaLeitura.App.HTML;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App.Logica
{
    public class CarregaLivros
    {
        public static Task VerDetalhesLivros(HttpContext context)
        {
            int id = Convert.ToInt32(context.GetRouteValue("id"));
            var _repo = new LivroRepositorioCSV();
            var livro = _repo.Todos.First(l => l.Id == id);
            return context.Response.WriteAsync(livro.Detalhes());
        }

        public static Task LivrosParaLer(HttpContext context)
        {
            var html = HTMLUtils.CarregarPaginaHTML("ParaLer");
            var _repo = new LivroRepositorioCSV();

            foreach (var livro in _repo.ParaLer.Livros)
            {
                html = html.Replace("#NOVOITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVOITEM#");
            }

            html = html.Replace("#NOVOITEM#", "");

            return context.Response.WriteAsync(html);
        }

        public static Task LivrosLendo(HttpContext context)
        {
            var html = HTMLUtils.CarregarPaginaHTML("Lendo");
            var _repo = new LivroRepositorioCSV();

            foreach (var livro in _repo.Lendo.Livros)
            {
                html = html.Replace("#NOVOITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVOITEM#");
            }

            html = html.Replace("#NOVOITEM#", "");

            return context.Response.WriteAsync(html);
        }

        public static Task LivrosLidos(HttpContext context)
        {
            var html = HTMLUtils.CarregarPaginaHTML("Lidos");
            var _repo = new LivroRepositorioCSV();

            foreach (var livro in _repo.Lidos.Livros)
            {
                html = html.Replace("#NOVOITEM#", $"<li>{livro.Titulo} - {livro.Autor}</li>#NOVOITEM#");
            }

            html = html.Replace("#NOVOITEM#", "");

            return context.Response.WriteAsync(html);
        }

        public static Task FormularioAdicionarLivros(HttpContext context)
        {
            var html = HTMLUtils.CarregarPaginaHTML("Formulario");

            return context.Response.WriteAsync(html);
        }
    }
}
