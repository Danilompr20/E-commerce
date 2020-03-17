using EComerce.Dominios.Contratos;
using EComerce.Dominios.Entidades;
using EComerce.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Repositorio.Repositorio
{
    public class PedidoRepositorio : BaseRepositorio<Pedido>, IPedidoRepositorio

    {
        public PedidoRepositorio(EcommerceContexto ecommerceContexto) : base(ecommerceContexto)
        {
        }
    }
}
