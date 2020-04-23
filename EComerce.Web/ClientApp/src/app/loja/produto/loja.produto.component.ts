import { Component, OnInit } from '@angular/core';
import { Produto } from '../../model/Produto';
import { ProdutoServico } from '../../servicos/produto/produto.servico';
import { Router } from '@angular/router';
import { LojaCarrinho } from '../carrinho/loja.carrinho.component';

@Component({
  selector: "loja-app-produto",
  templateUrl: "./loja.produto.component.html",
  styleUrls: ["./loja.produto.component.css"]

})

export class LojaProdutoComponent implements OnInit {
  public produto: Produto;
  public carrinho: LojaCarrinho;
  ngOnInit(): void {
    this.carrinho = new LojaCarrinho();
    
      var produtoDetalhe = sessionStorage.getItem("produtoDetalhe");
      if (produtoDetalhe) {
        //converte=o JSON em um obejeto e atribui ele a produto
        this.produto = JSON.parse(produtoDetalhe);

      }
  }
  constructor(private produtoServico: ProdutoServico,private router:Router) {

  }
  public comprar() {
    this.carrinho.adicionar(this.produto);
    this.router.navigate(['/loja-efetivar']);
  }
}
