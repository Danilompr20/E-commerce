using EComerce.Dominios.Entidades;
using EComerce.Dominios.Entidades.ObejtoDeValor;
using EComerce.Repositorio.Config;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;



namespace EComerce.Repositorio.Contexto
{
    public class EcommerceContexto : DbContext

    {
      
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedidos { get; set; }
        public DbSet<FormaPagamento> FormasPagamentos { get; set; }

        public EcommerceContexto(DbContextOptions options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());
            
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FormaPagamento>().HasData(new FormaPagamento()
            {
                FormaPagamentoId = 1,
                Nome = "Boleto",
                Descricao = "Forma de pagamento Boleto"
            },
            new FormaPagamento()
            {
                FormaPagamentoId = 2,
                Nome = "Não definido",
                Descricao = "Forma de pagamento não definida"
            },
             new FormaPagamento()
             {
                 FormaPagamentoId = 3,
                 Nome = "Cartão de Crédito",
                 Descricao = "Forma de pagamento cartão de crédtio"
             },
              new FormaPagamento()
              {
                  FormaPagamentoId = 4,
                  Nome = "Depósito",
                  Descricao = "Forma de pagamento Depósito"
              });
                
                
               
        }
    }
}
