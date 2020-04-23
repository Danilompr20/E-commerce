"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var LojaCarrinho = /** @class */ (function () {
    function LojaCarrinho() {
        this.produtos = [];
    }
    LojaCarrinho.prototype.adicionar = function (produto) {
        var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
        if (!produtoLocalStorage) {
            // se não existir nada no localStorage
            //add na lista de produto o produto que chegou por parametro
            this.produtos.push(produto);
            //add no localstorage a lista de pordutos convertido em JSON
            localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos));
        }
        else {
            // se ja existir no localStorage pelo menos um unico item armazenado, antes de add um novo produto
            // tem que converter a lista de json em produto, para ler os produtos ja armazenados no carrinho
            this.produtos = JSON.parse(produtoLocalStorage);
            this.produtos.push(produto);
            localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos));
        }
    };
    LojaCarrinho.prototype.obterProdutos = function () {
        var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
        if (produtoLocalStorage) {
            return JSON.parse(produtoLocalStorage);
        }
        else {
            return this.produtos;
        }
    };
    LojaCarrinho.prototype.removerProduto = function (produto) {
        var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
        if (produtoLocalStorage) {
            //pegando os dados salvos no localStorage, faz um filtro por id para remover
            this.produtos = JSON.parse(produtoLocalStorage);
            this.produtos = this.produtos.filter(function (p) { return p.produtoId != produto.produtoId; });
            localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos));
        }
    };
    LojaCarrinho.prototype.atualizar = function (produtos) {
        //passa o produto recebido por parametro
        localStorage.setItem("produtoLocalStorage", JSON.stringify(produtos));
    };
    return LojaCarrinho;
}());
exports.LojaCarrinho = LojaCarrinho;
//# sourceMappingURL=loja.carrinho.component.js.map