
using EComerce.Dominios.Entidades.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Dominios.Entidades.ObejtoDeValor
{
    public class FormaPagamento 
    {
        public int FormaPagamentoId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public bool EhBoleto
        {
            get { return FormaPagamentoId == (int)TipoFormaPagamentoEnum.Boleto; }
        }
        public bool EhCartao
        {
            get { return FormaPagamentoId == (int)TipoFormaPagamentoEnum.CartaoCredito; }
        }
        public bool EhDesposito
        {
            get { return FormaPagamentoId == (int)TipoFormaPagamentoEnum.Deposito; }
        }
        public bool naoFoiDedinido
        {
            get { return FormaPagamentoId == (int)TipoFormaPagamentoEnum.NaoDefinido; }
        }
    }
}
