using EComerce.Dominios.Contratos;
using EComerce.Dominios.Entidades;
using EComerce.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Repositorio.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(EcommerceContexto ecommerceContexto) : base(ecommerceContexto)
        {
        }
    }
}
