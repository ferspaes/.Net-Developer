using Alura.ListaLeitura.App.Negocio;
using Alura.ListaLeitura.App.Repositorio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Alura.ListaLeitura.App
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRouting();
        }

        public void Configure(IApplicationBuilder app)
        {
            var builder = new RouteBuilder(app);
            builder.MapRoute("Livros/ParaLer", LivrosParaLer);
            builder.MapRoute("Livros/Lendo", LivrosLendo);
            builder.MapRoute("Livros/Lidos", LivrosLidos);
            builder.MapRoute("Livros/Adicionar/{nome}/{autor}", AdicionarLivros);
            var router = builder.Build();

            app.UseRouter(router);

            //app.Run(Rotear);
        }

        public Task Rotear(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();
            var respostaURL = new Dictionary<string, RequestDelegate>()
            {
                { "/Livros/ParaLer", LivrosParaLer },
                { "/Livros/Lendo", LivrosLendo },
                { "/Livros/Lidos", LivrosLidos }
            };

            if (respostaURL.ContainsKey(contexto.Request.Path))
            {
                var metodo = respostaURL[contexto.Request.Path];
                return metodo.Invoke(contexto);
            }

            contexto.Response.StatusCode = 404;
            return contexto.Response.WriteAsync("Achou que escreveu a URL certo?! Achou errado colega!");
        }

        public Task AdicionarLivros(HttpContext contexto)
        {
            var livro = new Livro()
            {
                Titulo = Convert.ToString(contexto.GetRouteValue("nome")),
                Autor = Convert.ToString(contexto.GetRouteValue("autor"))
            };

            var _repo = new LivroRepositorioCSV();
            _repo.Incluir(livro);

            return contexto.Response.WriteAsync("Livro Adicionado com sucesso!");
        }

        public Task LivrosParaLer(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();
            return contexto.Response.WriteAsync(_repo.ParaLer.ToString());
        }

        public Task LivrosLendo(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();
            return contexto.Response.WriteAsync(_repo.Lendo.ToString());
        }

        public Task LivrosLidos(HttpContext contexto)
        {
            var _repo = new LivroRepositorioCSV();
            return contexto.Response.WriteAsync(_repo.Lidos.ToString());
        }
    }
}