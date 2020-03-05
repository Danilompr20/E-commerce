using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Dominios.Entidades
{
   public  class Usuario
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sonrenome { get; set; }
        public ICollection<Pedido> Pedidos { get; set; }

    }
}
