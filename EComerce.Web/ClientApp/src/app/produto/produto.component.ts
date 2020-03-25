import { Component } from '@angular/core';

@Component({
  selector: 'app-produto',
  template: './produto.component.html'

})
export class ProdutoComponent
{// nome dos metodos começa com maiuscula e variaveis e atributos com minusculo
  public nome: string;
  public liberadoParaVenda: boolean;

  public obterNome(): string {
    return "Sansung";
  }

}
