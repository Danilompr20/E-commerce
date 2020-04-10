using EComerce.Dominios.Contratos;
using EComerce.Dominios.Entidades;
using EComerce.Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EComerce.Repositorio.Repositorio
{
    public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(EcommerceContexto ecommerceContexto) : base(ecommerceContexto)
        {

        }

        public Usuario Obter(string email, string senha)
        {
            return EcommerceContexto.Usuarios.FirstOrDefault(u=> u.Email == email  &&  u.Senha == senha);
        }
    }
}
