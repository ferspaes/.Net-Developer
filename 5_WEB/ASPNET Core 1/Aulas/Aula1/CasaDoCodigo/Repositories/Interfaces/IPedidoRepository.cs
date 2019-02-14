using CasaDoCodigo.Models;

namespace CasaDoCodigo.Repositories
{
    public interface IPedidoRepository
    {
        Pedido GetPedido();
        void AddItem(string codigo);
        UpdateQuantidadeResponse UpdatePedidoQuantidade(ItemPedido itemPedido);

        Pedido UpdateCadastro(Cadastro cadastro);
    }
}
