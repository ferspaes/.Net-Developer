using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>, IItemPedidoRepository
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto) { }

        public void UpdatePedidoQuantidade(ItemPedido itemPedido)
        {
            throw new System.NotImplementedException();
        }
    }
}
