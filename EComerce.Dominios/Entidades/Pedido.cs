using EComerce.Dominios.Entidades.ObejtoDeValor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EComerce.Dominios.Entidades
{
    public class Pedido : Entidade
    {
        public int PedidoId { get; set; }
        public DateTime DatàPedido { get; set; }
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }
        public DateTime DataPrevisaoEntrega { get; set; }
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string EnderecoCompleto { get; set; }
        public int NumeroEndereco { get; set; }
        public int FormaPagamentoId { get; set; }
        public virtual FormaPagamento FormaPagamento { get; set; }


        // Um pedido deve ter um ou mais itens de pedido
        public virtual ICollection<ItemPedido> ItensPedidos{ get; set; }

        public override void Validate()
        {
            LimparMsg();
            if (!ItensPedidos.Any())
            {
                AdcionarCritica("Pedido não pode ficar sem item.");
            }

            if (string.IsNullOrEmpty(CEP))
            {
                AdcionarCritica("Cep não pode ser vazio");

            }
            if (FormaPagamentoId==0)
            {
                AdcionarCritica("Não foi informado a forma de pagamento");
            }
        }
    }
}
