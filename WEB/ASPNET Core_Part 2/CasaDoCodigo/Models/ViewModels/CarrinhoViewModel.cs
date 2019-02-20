using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Models.ViewModels
{
    public class CarrinhoViewModel
    {
        public IList<ItemPedido> Items { get; }

        public CarrinhoViewModel(IList<ItemPedido> items) => Items = items;

        public decimal Total => Items.Sum(item => item.Quantidade * item.PrecoUnitario);
    }
}
