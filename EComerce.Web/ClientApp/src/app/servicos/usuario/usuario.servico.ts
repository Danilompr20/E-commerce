import { Injectable, inject, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Usuario } from "../../model/Usuario";


// com injectable em qualquer classe eu posso injetar o usuarioServico no construtor
@Injectable({
  providedIn: 'root',
})
// essa classe é um provider em app module
export class UsuarioServico {

  private baseURl: string;
  private _usuario: Usuario;


  set usuario(usuario: Usuario) {

    //gerando json com base na instancia de usuario e armazena no sessionStorage na chave "usuario-autenticado"
    sessionStorage.setItem("usuario-autenticado", JSON.stringify(usuario));

    //atualiza a isntacia de usuario pelo parametro recebido no metodo verificarUsuario() no LoginComponent
    this._usuario = usuario;


  }

  get usuario(): Usuario {

    //recupera a informação que está em JSOn
    let usuario_json = sessionStorage.getItem("usuario-autenticado");

    //transforma o dado em JSON para o tipo usuario
    this._usuario = JSON.parse(usuario_json);
    return this._usuario;
  }


  public usuario_autenticado(): boolean {
    return this._usuario != null && this._usuario.email != "" && this._usuario.senha != "";



  }

  public limparSessao() {
    sessionStorage.setItem("usuario-autenticado", "");
    this._usuario = null;
  }


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseURl = baseUrl;
  }

  public vreficarUsuario(usuario: Usuario): Observable<Usuario> {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      email: usuario.email,
      senha: usuario.senha

    }
    //this.baseurl pega a raiz do site exemplo www.ecomerce/api/usuario

    return this.http.post<Usuario>(this.baseURl + "api/usuario/verificarusuario", body, { headers });


  }

}
