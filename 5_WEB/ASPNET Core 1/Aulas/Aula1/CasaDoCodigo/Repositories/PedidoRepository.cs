using CasaDoCodigo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;

        public PedidoRepository(ApplicationContext contexto, IHttpContextAccessor contextAccessor) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
        }

        public void AddItem(string codigo)
        {
            var produtoEncontrado = contexto.Set<Produto>()
                                        .Where(produto => produto.Codigo.Equals(codigo))
                                        .FirstOrDefault();

            if (produtoEncontrado.Equals(null))
                throw new ArgumentException("Produto não encontrado!");

            var pedidoEncontrado = GetPedido();

            var itemPedidoEncontrado = contexto.Set<ItemPedido>()
                                        .Where(itemPedido => itemPedido.Pedido.Id.Equals(pedidoEncontrado.Id)
                                               && itemPedido.Produto.Codigo.Equals(codigo))
                                        .SingleOrDefault();

            if (itemPedidoEncontrado.Equals(null))
            {
                itemPedidoEncontrado = new ItemPedido(pedidoEncontrado, produtoEncontrado, 1, produtoEncontrado.Preco);
                contexto.Set<ItemPedido>().Add(itemPedidoEncontrado);
                contexto.SaveChanges();
            }
        }

        public Pedido GetPedido()
        {
            var pedidoId = GetPedidoId();

            var pedidoEncontrado = DBSet
                                    .Include(pedido => pedido.Items)
                                        .ThenInclude(itemPedido => itemPedido.Produto)
                                    .Where(pedido => pedido.Id.Equals(pedidoId))
                                    .SingleOrDefault();

            if (pedidoEncontrado == null)
            {
                pedidoEncontrado = new Pedido();
                DBSet.Add(pedidoEncontrado);
                contexto.SaveChanges();
                SetPedidoId(pedidoEncontrado.Id);
            }

            return pedidoEncontrado;

        }

        private int? GetPedidoId()
        {
            return contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }
    }
}
