using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Dominios.Entidades 
{
    public class Usuario : Entidade
    {
        public int UsuarioId { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public virtual ICollection<Pedido> Pedidos { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Email))
            {
                AdcionarCritica("Email não pode ser vazio");

            }
            if (string.IsNullOrEmpty(Nome))
            {
                AdcionarCritica("Nome não pode ser vazio");

            }
            if (string.IsNullOrEmpty(Senha))
            {
                AdcionarCritica("Senha não pode ser vazio");

            }
        }
    }
}
