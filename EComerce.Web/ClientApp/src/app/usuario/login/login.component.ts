import { Component, OnInit } from "@angular/core";
import { Template } from "@angular/compiler/src/render3/r3_ast";
import { Usuario } from "../../model/Usuario";
import { Router, ActivatedRoute } from "@angular/router";
import { UsuarioServico } from "../../servicos/usuario/usuario.servico";
import { error } from "@angular/compiler/src/util";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.css"]

})

export class LoginComponent implements OnInit {


  public usuario;
  public returnUrl: string;
  public mensagem: string;
  private ativar_spinner: boolean;


  constructor(private router: Router, private activatedRouter: ActivatedRoute, private usuarioservico: UsuarioServico) {


  }
  ngOnInit(): void {
    this.returnUrl = this.activatedRouter.snapshot.queryParams['returnUrl']
   this.usuario = new Usuario();
   
  }
  entrar(): void {
    this.ativar_spinner = true;
    // metodo criado em usuarioServico
    this.usuarioservico.vreficarUsuario(this.usuario)
      .subscribe(

        //será executada em caso de retorno sem erro
        //data é o json devolvido pelo controller do usuario
        usuario_json => {
          console.log(usuario_json);
          //sessionStorage.setItem("usuario-autenticado", "1");
          this.usuarioservico.usuario = this.usuario;
          
          if (this.returnUrl == null) {
            this.router.navigate(['/']);
          }
          else {
            this.router.navigate([this.returnUrl]);
          }

        },
        err => {
          console.log(err.error);
          this.ativar_spinner = false;
          this.mensagem = err.error;

        }
      );



    //if (this.usuario.email == "danilompr@hotmail.com" && this.usuario.senha == "123") {
    //  sessionStorage.setItem("usuario-autenticado", "1");
    //  this.router.navigate([this.returnUrl]);

  }
}



