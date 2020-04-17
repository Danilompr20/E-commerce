using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Dominios.Entidades
{
    public class Produto : Entidade
    {
        public int ProdutoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Preco { get; set; }
        public string NomeArquivo { get; set; }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(Descricao))
            {
                AdcionarCritica("Nome do produto não pode ser vazio");

            }

            if (Preco==0)
            {
                AdcionarCritica("Informe o preço do produto");

            }
        }


    }
}
