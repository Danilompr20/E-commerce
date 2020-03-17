
using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Dominios.Entidades
{
    public class ItemPedido : Entidade
    {
        public int ItemPedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int PedidoId { get; set; }
        public virtual Pedido Pedido { get; set; }
        public int Quantidade { get; set; }

        public override void Validate()
        {
            if (ProdutoId==0)
            {
                AdcionarCritica("Não foi indentificado qual o produto");
            }

            if (Quantidade==0)
            {
                AdcionarCritica("Quantidade não ofi informado");


            }

        }


    }
}
