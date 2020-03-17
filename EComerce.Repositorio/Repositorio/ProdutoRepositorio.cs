using EComerce.Dominios.Contratos;
using EComerce.Dominios.Entidades;
using EComerce.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Repositorio.Repositorio
{
    public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(EcommerceContexto ecommerceContexto) : base(ecommerceContexto)
        {
        }
    }
}
