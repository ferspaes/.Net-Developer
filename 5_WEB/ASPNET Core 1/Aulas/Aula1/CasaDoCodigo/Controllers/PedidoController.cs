using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using CasaDoCodigo.Repositories;
using CasaDoCodigo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepository produtoRepository;
        private readonly IPedidoRepository pedidoRepository;
        private readonly IItemPedidoRepository itemPedidoRepository;

        public PedidoController(IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            this.produtoRepository = produtoRepository;
            this.pedidoRepository = pedidoRepository;
            this.itemPedidoRepository = itemPedidoRepository;
        }

        public IActionResult Carrossel()
        {
            return View(produtoRepository.GetProdutos());
        }

        public IActionResult Cadastro()
        {
            return View();
        }

        public IActionResult Carrinho(string codigo)
        {
            if (!string.IsNullOrWhiteSpace(codigo))
                pedidoRepository.AddItem(codigo);

            List<ItemPedido> items = pedidoRepository.GetPedido().Items;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(items);

            return View(carrinhoViewModel);
        }

        public IActionResult Resumo()
        {
            return View();
        }

        [HttpPost]
        public UpdateQuantidadeResponse UpdateQuantidadePedido([FromBody]ItemPedido item)
        {
            return pedidoRepository.UpdatePedidoQuantidade(item);
        }
    }
}
