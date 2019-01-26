using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Alura.ListaLeitura.App.Logica
{
    public class LivrosController
    {

        public IEnumerable<Livro> Livros { get; set; }

        public string Detalhes(int id)
        {
            var _repo = new LivroRepositorioCSV();
            var livro = _repo.Todos.First(l => l.Id == id);
            return livro.Detalhes();
        }

        public IActionResult ParaLer()
        {
            var _repo = new LivroRepositorioCSV();
            var html = new ViewResult { ViewName = "Lista" };
            ViewBag.Livros = _repo.ParaLer.Livros;

            return html;
        }

        public IActionResult Lendo()
        {
            var _repo = new LivroRepositorioCSV();
            var html = new ViewResult { ViewName = "Lista" };

            return html;
        }

        public IActionResult Lidos(HttpContext context)
        {
            var _repo = new LivroRepositorioCSV();
            var html = new ViewResult { ViewName = "Lista" };

            return html;
        }

        public IActionResult Formulario()
        {
            var html = new ViewResult { ViewName = "formulario" };
            return html;
        }

        public string Teste()
        {
            return "Testando nova implementaçào!";
        }
    }
}
