
using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Dominios.Entidades
{
    public class ItemPedido
    {
        public int ItemPedidoId { get; set; }
        public int ProdutoId { get; set; }
        public int Quantidade { get; set; }
    }
}
