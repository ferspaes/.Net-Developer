using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories.Interfaces;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto) { }

        public ItemPedido GetItemPedido(int idItemPedido)
        {
            return DBSet
                    .Where(item => item.Id == idItemPedido)
                    .SingleOrDefault();
        }
    }
}
