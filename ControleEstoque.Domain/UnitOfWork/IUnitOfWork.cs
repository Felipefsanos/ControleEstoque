using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void SaveChanges();
    }
}
