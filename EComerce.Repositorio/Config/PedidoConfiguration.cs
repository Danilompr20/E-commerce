using EComerce.Dominios.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Repositorio.Config
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(p => p.PedidoId);

            builder.Property(p => p.Cidade)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.CEP)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.DataPrevisaoEntrega)
                   .IsRequired();

            builder.Property(p => p.DatàPedido)
                   .IsRequired();

            builder.Property(p => p.EnderecoCompleto)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.Estado)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.NumeroEndereco)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.FormaPagamentoId)
                   .IsRequired()
                   .HasMaxLength(50);
            builder.HasMany(p=> p.ItensPedidos).WithOne(i=> i.Pedido);
           
        
    }
    }
}
