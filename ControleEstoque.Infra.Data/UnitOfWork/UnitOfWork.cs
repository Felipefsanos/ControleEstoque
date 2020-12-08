using ControleEstoque.Domain.UnitOfWork;
using ControleEstoque.Infra.Data.Context;
using System;
namespace ControleEstoque.Infra.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ControleEstoqueContext context;

        public UnitOfWork(ControleEstoqueContext context)
        {
            this.context = context;
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
