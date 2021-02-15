using ControleEstoque.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ControleEstoque.Infra.Data.Context
{
    public class ControleEstoqueContext : DbContext
    {
        public ControleEstoqueContext(DbContextOptions<ControleEstoqueContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cliente>()
                .HasMany<Endereco>()
                .WithOne(c => c.Cliente)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Telefone>()
                .HasOne(x => x.Cliente)
                .WithMany(x => x.Telefones)
                .HasForeignKey("ClienteId")
                .OnDelete(DeleteBehavior.Cascade);
        }

        public IQueryable<TEntity> GetDbSetWithIncludes<TEntity>(params string[] includes) where TEntity : class
        {
            IQueryable<TEntity> dbSet = Set<TEntity>();

            if (includes?.Length > 0)
                foreach (var include in includes)
                    dbSet = dbSet.Include(include);

            return dbSet;
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

    }
}
