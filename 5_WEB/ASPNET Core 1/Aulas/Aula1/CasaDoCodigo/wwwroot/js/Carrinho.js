
class Carrinho {
    clickIncremento(btn) {
        let data = this.getData(btn);
        data.Quantidade++;
        this.postQuantidade(data);
    }

    clickDecremento(btn) {
        let data = this.getData(btn);
        data.Quantidade--;
        this.postQuantidade(data);
    }

    updateQuantidade(input) {
        let data = this.getData(input);
        this.postQuantidade(data);
    }

    getData(elemento) {
        var linhaDoItem = $(elemento).parents('[item-id]');
        var idProduto = $(linhaDoItem).attr('item-id');
        var itemQtde = $(linhaDoItem).find('input').val();

        return {
            Id: idProduto,
            Quantidade: itemQtde
        };
    }

    postQuantidade(data) {
        $.ajax({
            url: '/Pedido/UpdateQuantidadePedido',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(data)
        }).done(function (response) {
            debugger;

            let itemPedido = response.itemPedido;
            let linhaDoItem = $('[item-id=' + itemPedido.id + ']');

            linhaDoItem.find('input').val(itemPedido.quantidade);
            linhaDoItem.find('[subtotal]').html((itemPedido.subTotal).duasCasas());

            let carrinhoViewModel = response.carrinhoViewModel;

            $('[numero-itens]').html('Total: ' + carrinhoViewModel.items.length + ' itens');
            $('[total]').html((carrinhoViewModel.total).duasCasas());

            if (itemPedido.quantidade === 0) {
                linhaDoItem.remove();
            }
        });
    }
}

var carrinho = new Carrinho();

Number.prototype.duasCasas = function () {
    return this.toFixed(2).replace('.', ',');
}