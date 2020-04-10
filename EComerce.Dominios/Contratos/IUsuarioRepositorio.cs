using EComerce.Dominios.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Dominios.Contratos
{
    public interface IUsuarioRepositorio : IBaseRepositorio<Usuario>
    {
        Usuario Obter(string email, string senha);
    }
}
