﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Models
{
    public class Pedido : BaseModel
    {
        public List<ItemPedido> Items { get; private set; } = new List<ItemPedido>();

        [Required]
        public virtual Cadastro Cadastro { get; private set; }

        public Pedido()
        {
            Cadastro = new Cadastro()
            {
                Bairro = "bairro",
                CEP = "cep"
            };
        }

        public Pedido(Cadastro cadastro)
        {
            Cadastro = cadastro;
        }
    }
}