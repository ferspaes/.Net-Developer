using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories.Interfaces
{
    public interface IItemPedidoRepository
    {
        ItemPedido GetItemPedido(int idItemPedido);
        void RemoveItemPedido(int idItemPedido);
    }
}
