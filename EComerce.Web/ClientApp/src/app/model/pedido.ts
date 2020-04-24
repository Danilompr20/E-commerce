import { ItemPedido } from "./itemPedido";

export class Pedido {


  public pedidoId: number;
  public datàPedido: Date;
  public usuarioId: number;
  public dataPrevisaoEntrega: Date;
  public cep: string;
  public cidade: string;
  public estado: string;
  public enderecoCompleto:string;
  public numeroEndereco: number;
  public formaPagamentoId: number;
  public itensPedidos: ItemPedido[];

  constructor() {
    //inicia uma lista vazia
    this.itensPedidos = [];
  }

}
