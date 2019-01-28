using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Models
{
    public class ItemPedido : BaseModel
    {
        [Required]
        public Pedido Pedido { get; set; }

        [Required]
        public Produto Produto { get; set; }

        [Required]
        public int Quantidade { get; set; }

        [Required]
        public decimal PrecoUnitario { get; set; }

        public ItemPedido() { }

        public ItemPedido(Pedido pedido, Produto produto, int quantidade, decimal precoUnitario)
        {
            Pedido = pedido;
            Produto = produto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }
    }
}