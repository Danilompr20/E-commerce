import { Component, OnInit } from '@angular/core';
import { Produto } from '../../model/Produto';
import { ProdutoServico } from '../../servicos/produto/produto.servico';
import { Router } from '@angular/router';


@Component({
  selector: "pesquisa-produto",
  templateUrl: "./pesquisa.produto.component.html",
  styleUrls: ["./pesquisa.produto.component.css"]

})
export class PesquisaProdutoComponent implements OnInit {
  public produtos: Produto[];


  ngOnInit(): void {
      
  }

  constructor(private produtoServico: ProdutoServico ,private router:Router) {
    this.produtoServico.obterTodosProdutos()
      .subscribe(produtos => {
        this.produtos = produtos;


    },
        e => {
          console.log(e.error)
        
  });

  }

  public adicionarProduto() {
    this.router.navigate(['/produto']);
  }
  // recebe por parametro o produto do template
  public deletarProduto(produto: Produto) {
    var retorno = confirm("Deseja realmente deletar o produto selecionado");

    if (retorno == true) {
      //envia a api o produto recebido do template no metodo deletarProduto()
      this.produtoServico.deletar(produto).subscribe(
        produtos => {
         
          //atualiza a lista de produtos através do que foi retornado pela api
          this.produtos = produtos;
        },
        e => {
          console.log(e.errors);
        }
      );

    }
  }
  public editarProduto(produto:Produto ) {
    sessionStorage.setItem("produtoSessao", JSON.stringify(produto));
    this.router.navigate(['/produto']);
  }

}
