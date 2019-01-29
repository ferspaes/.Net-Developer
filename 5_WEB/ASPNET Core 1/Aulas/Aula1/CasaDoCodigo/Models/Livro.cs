using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace CasaDoCodigo.Models
{
    public class Livro : ILivro
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }

        public List<Livro> GetLivros()
        {
            var json = File.ReadAllText("livros.json");
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json);
            return livros;
        }
    }
}
