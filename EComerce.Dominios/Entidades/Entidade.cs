﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EComerce.Dominios.Entidades
{
    public abstract class Entidade
    {
        private List<string> _mensagensValidacao { get; set; }
        private List<string> mensagemValidacao
        {
            get { return _mensagensValidacao ?? (_mensagensValidacao = new List<string>()); }
        }

        protected void LimparMsg()
        {
            mensagemValidacao.Clear();
        }

        protected void AdcionarCritica(string mensagem)
        {
            mensagemValidacao.Add(mensagem);

        }

        public string ObterMesnsagensValidacao()
        {
            return string.Join(". ",mensagemValidacao);
        }

        public abstract void Validate();

        public bool EhValido
        {
            get { return !mensagemValidacao.Any(); }
        }
    }
}
