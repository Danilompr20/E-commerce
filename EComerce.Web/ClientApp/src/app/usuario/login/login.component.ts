import { Component } from "@angular/core";
import { Template } from "@angular/compiler/src/render3/r3_ast";
import { Usuario } from "../../model/Usuario";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls:["./login.component.css"]
    
})

export class LoginComponent
{

  public usuario;
  
  constructor() {
    this.usuario = new Usuario();
  }
  entrar(): void {
    if (this.usuario.email == "Danilo" && this.usuario.senha== "123") {
     
    }
  }

  
}
