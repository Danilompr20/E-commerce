using EComerce.Dominios.Entidades.ObejtoDeValor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Repositorio.Config
{
    public class FormaPagamentoConfiguration : IEntityTypeConfiguration<FormaPagamento>

    {
        public void Configure(EntityTypeBuilder<FormaPagamento> builder)
        {
        }
    }
}
