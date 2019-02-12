using CasaDoCodigo.Models;
using CasaDoCodigo.Repositories;
using CasaDoCodigo.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

            Pedido pedido = pedidoRepository.GetPedido();
            return View(pedido.Items);
        }

        public IActionResult Resumo()
        {
            return View();
        }

        [HttpPost]
        public void UpdateQuantidadePedido([FromBody]ItemPedido item)
        {
            itemPedidoRepository.UpdatePedidoQuantidade(item);
        }
    }
}
