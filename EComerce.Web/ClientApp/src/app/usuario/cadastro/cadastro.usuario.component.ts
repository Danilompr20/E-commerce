import { Component, OnInit } from '@angular/core';
import { Usuario } from '../../model/Usuario';
import { UsuarioServico } from '../../servicos/usuario/usuario.servico';
@Component({
  selector: 'cadastro-usuario',
  templateUrl: './cadastro.usuario.component.html',
  styleUrls: ['./cadastro.usuario.component.css']
})

export class CadastroUsuarioComponent implements OnInit {
  public usuario: Usuario;
  public ativar_spinner: boolean;
  public mensagem: string;
  public usuarioCadastrado: boolean;

  constructor(private usuarioServico: UsuarioServico) {

  }

  ngOnInit(): void {
    this.usuario = new Usuario;
  }


  public cadastrar() {
    //recebe o usuario digitado no template através do bind
    this.ativar_spinner = true;
    //Passa o usuario por parametro para o metodo usuarioServico
    this.usuarioServico.cadastrarUsuario(this.usuario)
      .subscribe(
        usuarioJSON => {
          this.usuarioCadastrado = true;
          this.mensagem = "";
          this.ativar_spinner = false;
        },
        e => {
          this.mensagem = e.error;
          this.ativar_spinner = false;
        }
      );
  }

}
