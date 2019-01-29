using CasaDoCodigo.Models;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>().HasKey(produto => produto.Id);

            modelBuilder.Entity<Pedido>().HasKey(produto => produto.Id);
            modelBuilder.Entity<Pedido>().HasMany(pedido => pedido.Items).WithOne(item => item.Pedido);
            modelBuilder.Entity<Pedido>().HasOne(pedidos => pedidos.Cadastro).WithOne(cadastro => cadastro.Pedido);

            modelBuilder.Entity<ItemPedido>().HasKey(produto => produto.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(item => item.Pedido);
            modelBuilder.Entity<ItemPedido>().HasOne(pedido => pedido.Produto);

            modelBuilder.Entity<Cadastro>().HasKey(produto => produto.Id);
            modelBuilder.Entity<Cadastro>().HasOne(cadastro => cadastro.Pedido);
        }
    }
}
