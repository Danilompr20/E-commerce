﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using EComerce.Dominios.Entidades;

namespace EComerce.Repositorio.Config
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
     

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.HasKey(u => u.UsuarioId);
            //padrao fluent
            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(u => u.Nome)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(u => u.Sobrenome)
                .IsRequired()
                .HasMaxLength(50);
            builder
                .Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(400);

            builder.HasMany(u => u.Pedidos).WithOne(p => p.Usuario);
        }
    }
}