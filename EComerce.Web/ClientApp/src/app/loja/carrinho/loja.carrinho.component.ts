import { Produto } from "../../model/Produto";

export class LojaCarrinho {
  public produtos: Produto[] = [];

  public adicionar(produto: Produto) {
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

    


  }
  public obterProdutos(): Produto [] {
    var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
    if (produtoLocalStorage) {
      return JSON.parse(produtoLocalStorage);
    }
    else {
      return this.produtos;

    }

  }
  public removerProduto(produto: Produto) {
    var produtoLocalStorage = localStorage.getItem("produtoLocalStorage");
    if (produtoLocalStorage) {
      //pegando os dados salvos no localStorage, faz um filtro por id para remover
      this.produtos = JSON.parse(produtoLocalStorage);
      this.produtos = this.produtos.filter(p => p.produtoId != produto.produtoId);
      localStorage.setItem("produtoLocalStorage", JSON.stringify(this.produtos));
    }
    
  }
  public atualizar(produtos: Produto[]) {
    //passa o produto recebido por parametro
    localStorage.setItem("produtoLocalStorage", JSON.stringify(produtos));

  }
}
