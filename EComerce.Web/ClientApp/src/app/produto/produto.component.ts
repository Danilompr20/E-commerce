import { Component, OnInit } from '@angular/core';
import { Produto } from '../model/Produto';
import { ProdutoServico } from '../servicos/produto/produto.servico';
import { Route, Router } from '@angular/router';

@Component({
  selector: "app-produto",
  templateUrl: "./produto.component.html",
  styleUrls: ["./produto.component.css"]

})
export class ProdutoComponent implements OnInit 
{
   // nome dos metodos começa com maiuscula e variaveis e atributos com minusculo
  public produto: Produto;
  public arquivoSelecionado: File;
  public ativar_spinner: boolean;
  public mensagem:string;

  constructor(private produtoServico: ProdutoServico ,private router: Router) {


  }

  ngOnInit(): void {
    this.produto = new Produto();
  }

  //metodo chamado no evento change do tamplate para capturar a imagem inserida
  //dentro desse metodo é chamada a funçao enviar arquivo passando para ele o arquivo selecionado, este metodo sem encontra no produtoServico
  public inputChange(files: FileList) {
    this.arquivoSelecionado = files.item(0);
    this.ativar_spinner = true;
    this.produtoServico.enviarArquivo(this.arquivoSelecionado)
      .subscribe(
        nomeArquivo => {
          alert(nomeArquivo);
          //pega o nome da imagem retorna pela api
          this.produto.nomeArquivo = nomeArquivo;
        
          console.log(nomeArquivo);
          this.ativar_spinner = false;
        },
        e => {
          this.ativar_spinner = false;
          console.log(e);
        }
    );
  }


  public cadastrar() {
    this.ativarEspera();
    this.produtoServico.cadastrar(this.produto)
      .subscribe(
        produtoJson => {
          console.log(produtoJson);
          this.desativarEspera();
          this.router.navigate(['/pesquisar-produto']);
        },
        e => {
          console.log(e.error);
          this.mensagem = e.error;
          this.desativarEspera();
        }
      );
  }
  public ativarEspera() {
    this.ativar_spinner = true;

  }

  public desativarEspera() {
    this.ativar_spinner = false;

  }


}
