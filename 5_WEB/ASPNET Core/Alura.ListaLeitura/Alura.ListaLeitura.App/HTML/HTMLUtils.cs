using System.IO;

namespace Alura.ListaLeitura.App.HTML
{
    public class HTMLUtils
    {
        public static string CarregarPaginaHTML(string nomeArquivo)
        {
            var nomeCompletoArquivo = $"HTML/{nomeArquivo}.html";
            using (var pagina = File.OpenText(nomeCompletoArquivo))
            {
                return pagina.ReadToEnd();
            }
        }
    }
}
