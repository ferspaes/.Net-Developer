using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories.Interfaces;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto) { }

        public ItemPedido GetItemPedido(int idItemPedido) => DBSet
                    .Where(item => item.Id == idItemPedido)
                    .SingleOrDefault();

        public void RemoveItemPedido(int idItemPedido)
        {
            var itemPedido = GetItemPedido(idItemPedido);
            DBSet.Remove(itemPedido);
        }
    }
}
