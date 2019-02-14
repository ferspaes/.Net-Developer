﻿using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Models
{
    public class Cadastro : BaseModel
    {
        public virtual Pedido Pedido { get; set; }

        [MinLength(5, ErrorMessage = "Nome deve ter no mínimo 5 caracteres.")]
        [MaxLength(50, ErrorMessage = "Nome deve ter no máximo 50 caracteres.")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; } = "";


        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Telefone { get; set; } = "";

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Endereco { get; set; } = "";

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Complemento { get; set; } = "";

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Bairro { get; set; } = "";

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Municipio { get; set; } = "";

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string UF { get; set; } = "";

        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string CEP { get; set; } = "";

        public Cadastro() { }
    }
}
