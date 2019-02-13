using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{
    [DataContract]
    public class ItemPedido : BaseModel
    {
        [Required]
        [DataMember]
        public Pedido Pedido { get; set; }

        [Required]
        [DataMember]
        public Produto Produto { get; set; }

        [Required]
        [DataMember]
        public int Quantidade { get; set; }

        [Required]
        [DataMember]
        public decimal PrecoUnitario { get; set; }

        public ItemPedido() { }

        public ItemPedido(Pedido pedido, Produto produto, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        internal void AtualizarQuantidade(int quantidade)
        {
            Quantidade = quantidade;
        }
    }
}