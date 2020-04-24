import { Component, OnInit } from '@angular/core';

@Component({

  templateUrl: './loja.compra.realizada.component.html'

})

export class LojaCompraRealizadaComponent implements OnInit {
  //pega o pedidoId que ta na sessionstorage ao efetivar a compra
  public pedidoId: string;
  ngOnInit(): void {

    this.pedidoId = sessionStorage.getItem("pedidoId");

    }

}
