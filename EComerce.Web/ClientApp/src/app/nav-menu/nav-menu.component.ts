import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { UsuarioServico } from '../servicos/usuario/usuario.servico';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  constructor(private router: Router, private usuarioServico: UsuarioServico) {
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  ///Funçaõ que recupera se o usuario está logado  usada no template do nav-menu
  public usuarioLogado(): boolean {

    // retorna um metodo acessado do usuarioServico
    return this.usuarioServico.usuario_autenticado(); 
  }

  //definir se o usuario é adm
  public usuario_administrador(): boolean {
    return this.usuarioServico.usuario_administrador();
  }

  // função para deslogar usada no template do nav-menu
  public sair(): void {
    this.usuarioServico.limparSessao();
    this.router.navigate(['/']);
  }

  get usuario() {
    return this.usuarioServico.usuario;
  }
}
