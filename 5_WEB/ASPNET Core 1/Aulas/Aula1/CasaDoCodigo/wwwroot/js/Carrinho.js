
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
        });
    }
}

var carrinho = new Carrinho();