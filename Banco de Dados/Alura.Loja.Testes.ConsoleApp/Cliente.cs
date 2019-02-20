using System;

namespace Alura.Loja.Testes.ConsoleApp
{
    public class Cliente
    {
        public Cliente() { }

        public int Id { get; set; }
        public string Nome { get; internal set; }
        public Endereco EnderecoDeEntrega { get; set; }
        public string Telefone { get; internal set; }
        public DateTime DataNascimento { get; internal set; }
    }
}