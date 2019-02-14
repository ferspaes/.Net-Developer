using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using CasaDoCodigo.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CasaDoCodigo.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor contextAccessor;
        private readonly IItemPedidoRepository itemPedidoRepository;
        private readonly ICadastroRepository cadastroRepository;

        public PedidoRepository(ApplicationContext contexto,
            IHttpContextAccessor contextAccessor,
            IItemPedidoRepository itemPedidoRepository,
            ICadastroRepository cadastroRepository) : base(contexto)
        {
            this.contextAccessor = contextAccessor;
            this.itemPedidoRepository = itemPedidoRepository;
            this.cadastroRepository = cadastroRepository;
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

            if (itemPedidoEncontrado == null)
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

        private int? GetPedidoId() => contextAccessor.HttpContext.Session.GetInt32("pedidoId");

        private void SetPedidoId(int pedidoId) => contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);

        public UpdateQuantidadeResponse UpdatePedidoQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = itemPedidoRepository.GetItemPedido(itemPedido.Id);

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizarQuantidade(itemPedido.Quantidade);

                if (itemPedidoDB.Quantidade == 0)
                    itemPedidoRepository.RemoveItemPedido(itemPedidoDB.Id);

                contexto.SaveChanges();

                var carrinhoViewModel = new CarrinhoViewModel(GetPedido().Items);
                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
            }

            throw new ArgumentException("Item Pedido Não Encontrado!");
        }

        public Pedido UpdateCadastro(Cadastro cadastro)
        {
            var pedido = GetPedido();
            cadastroRepository.Update(pedido.Cadastro.Id, cadastro);
            return pedido;
        }
    }
}
