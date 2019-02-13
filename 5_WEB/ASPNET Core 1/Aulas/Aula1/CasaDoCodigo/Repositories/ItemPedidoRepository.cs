using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories.Interfaces;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto) { }

        public void UpdatePedidoQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = DBSet
                                .Where(item => item.Id == itemPedido.Id)
                                .SingleOrDefault();

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizarQuantidade(itemPedido.Quantidade);
                contexto.SaveChanges();
            }
        }
    }
}
