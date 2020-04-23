import { Component, OnInit } from '@angular/core';
import { LojaCarrinho } from '../carrinho/loja.carrinho.component';
import { Produto } from '../../model/Produto';

@Component({
  selector: 'loeja-efetivar',
  templateUrl: './loja.efetivar.component.html',
  styleUrls: ['./loja.efetivar.component.css']
})

export class LojaEfetivarComponent implements OnInit {
  public carrinho: LojaCarrinho;
  public produtos: Produto[];
  public total: number;

  ngOnInit(): void {
    //metodo que lista todos itens do local storage
    this.carrinho = new LojaCarrinho();
 
    this.produtos = this.carrinho.obterProdutos();
    this.atualizarTotal();
      
  }
  public atualizarPreco(produto: Produto, quantidade: number) {
    if (!produto.precoOriginal) {
      produto.precoOriginal = produto.preco

    }
    //não deixar que o usuario digite 0 
    if (quantidade <=0) {
      quantidade = 1;
      //atualizando a quantidade da lista de produtos salva na sessão
      produto.quantidade = quantidade;
    }

    produto.preco = produto.precoOriginal * quantidade;
    this.carrinho.atualizar(this.produtos);
    this.atualizarTotal();
  }

  public remover(produto: Produto) {
    this.carrinho.removerProduto(produto);
    //atualizar o localstorage
    this.produtos = this.carrinho.obterProdutos();
    this.atualizarTotal();
  }
  public atualizarTotal() {
    //percorre toos itens da lista salva na sessão e acumula o preço
    this.total = this.produtos.reduce((acc, produto) => acc + produto.preco,0);
  }

  public efetivarCompra() {
      
  }

}
