using EComerce.Dominios.Entidades.ObejtoDeValor;
using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Dominios.Entidades
{
    public class Pedido
    {
        public int PedidoId { get; set; }
        public DateTime DatàPedido { get; set; }
        public int UserId { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }
        public int FormaPagamentoId { get; set; }
        public FormaPagamento FormaPagamento { get; set; }


        // Um pedido deve ter um ou mais itens de pedido
        public ICollection<ItemPedido> ItensPedidos{ get; set; }
    }
}
