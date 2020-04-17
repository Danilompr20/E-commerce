import { Injectable, Inject, OnInit } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { Produto } from "../../model/Produto";

@Injectable({
  providedIn:"root"

})

export class ProdutoServico  implements OnInit{
  
 
  private baseUrl: string;
  public produto: Produto[];


  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
 //baseUrl= pega o endereço raíz do site
    this.baseUrl = baseUrl;
  }
  ngOnInit(): void {
    this.produto = [];
  }
  
  // propriedade somente leitura para devolver o httpHeader
  get headers(): HttpHeaders {
    return new HttpHeaders().set('content-type', 'application/json');
  }
  public cadastrar(produto: Produto): Observable<Produto> {
    //aplication/json defini que a estrutura da requisição será um JSON, esta contante foi substituida pela
    //propriedade headers
    //const headers = new HttpHeaders().set('content-type', 'application/json');
    
    return this.http.post<Produto>(this.baseUrl + "api/produto", JSON.stringify(produto), { headers:this.headers });

  }

  public alterar(produto: Produto): Observable<Produto> {

    //const headers = new HttpHeaders().set('content-type',  'application/json');

  
    return this.http.post<Produto>(this.baseUrl + "", JSON.stringify(produto), { headers: this.headers });

  }

  public deletar(produto: Produto): Observable<Produto> {

    //const headers = new HttpHeaders().set('content-type', 'application/json');

   
    return this.http.post<Produto>(this.baseUrl + "", JSON.stringify(produto), { headers: this.headers });

  }

  public obterTodosProdutos(): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.baseUrl + "api/produto");

  }
  public obterProduto(produtoId:number): Observable<Produto[]> {
    return this.http.get<Produto[]>(this.baseUrl + "");

  }

  public enviarArquivo(arquivoSelecionado: File): Observable<string> {
    //metodo para passar para a api do asp net a imagem selecionada
    const formData: FormData = new FormData();
    
    formData.append("arquivoEnviado", arquivoSelecionado, arquivoSelecionado.name);
    return this.http.post<string>(this.baseUrl + "api/produto/enviarArquivo", formData);
  }

}
