using Alura.ListaLeitura.App.Logica;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

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
            builder.MapRoute("Livros/ParaLer", CarregaLivros.LivrosParaLer);
            builder.MapRoute("Livros/Lendo", CarregaLivros.LivrosLendo);
            builder.MapRoute("Livros/Lidos", CarregaLivros.LivrosLidos);
            builder.MapRoute("Livros/Detalhes/{id:int}", CarregaLivros.VerDetalhesLivros);
            builder.MapRoute("Livros/Adicionar/", CarregaLivros.FormularioAdicionarLivros);
            builder.MapRoute("Livros/Incluir/", CadastroLogica.TrataFormulario);

            var router = builder.Build();
            app.UseRouter(router);
        }
    }
}