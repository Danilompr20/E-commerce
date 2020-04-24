import { Component, OnInit } from '@angular/core';
import { LojaCarrinho } from '../carrinho/loja.carrinho.component';
import { Produto } from '../../model/Produto';
import { Pedido } from '../../model/pedido';
import { UsuarioServico } from '../../servicos/usuario/usuario.servico';
import { ItemPedido } from '../../model/itemPedido';
import { PedidoServico } from '../../servicos/pedido/pedido.servico';
import { Router } from '@angular/router';

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
    //pega todos produtos do localStorage
    this.produtos = this.carrinho.obterProdutos();
    this.atualizarTotal();

  }

  constructor(private usuarioServico: UsuarioServico, private pedidoServico: PedidoServico, private router:Router) {


  }
  public atualizarPreco(produto: Produto, quantidade: number) {
    if (!produto.precoOriginal) {
      produto.precoOriginal = produto.preco

    }
    //não deixar que o usuario digite 0 
    if (quantidade <= 0) {
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
    this.total = this.produtos.reduce((acc, produto) => acc + produto.preco, 0);
  }
  //faz a chamada a web api
  public efetivarCompra() {
    //passa como parametro  o metodo que cria um pedido
    this.pedidoServico.efetivarCompra(this.criarPedido())
      .subscribe(
        pedidoId => {
          console.log(pedidoId);
          //passa o pedido para sessão para usar na tela de compra efetuada com sucesso 
          sessionStorage.setItem("pedidoId", pedidoId.toString());
          this.produtos = [];
          this.carrinho.limparCarrinho();
          //redirecionar para outra pagina
          this.router.navigate(['/compra-realizada']);
        },

        e => {
          console.log(e.error);
        });

  }
  //adcionando itens ao pedido
  public criarPedido(): Pedido {
    let pedido = new Pedido();
    pedido.usuarioId = this.usuarioServico.usuario.usuarioId;
    pedido.cep = "12313123";
    pedido.cidade = "Itu";
    pedido.datàPedido = new Date();
    pedido.estado = "São Paulo";
    pedido.dataPrevisaoEntrega = new Date();
    pedido.formaPagamentoId = 1;
    pedido.numeroEndereco = 213;
    pedido.enderecoCompleto = "Rancho grande"
    this.carrinho.obterProdutos();
    //perccorendo a coleção de produtos armazenada no localStorage, o valor foi obtido no onInit
    for (let produto of this.produtos) {
      let itemPedido = new ItemPedido();
      itemPedido.produtoId = produto.produtoId;
      
      if (!produto.quantidade) {
        produto.quantidade = 1;
        itemPedido.quantidade = produto.quantidade;
        pedido.itensPedidos.push(itemPedido);

      }

    }

    return pedido;
}

}
