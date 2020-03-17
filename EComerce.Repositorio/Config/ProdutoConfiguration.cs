using EComerce.Dominios.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace EComerce.Repositorio.Config
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p=>p.ProdutoId);
            
            
            builder.Property(p => p.Descricao)
                   .IsRequired()
                   .HasMaxLength(50);
            
            builder.Property(p => p.Nome)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(p => p.Preco)
                   .IsRequired();

          //  builder.HasMany(p=> p.i)
        }
    }
}
