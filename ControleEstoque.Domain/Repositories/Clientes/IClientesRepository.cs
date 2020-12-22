using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Domain.Repositories.Clientes
{
    public interface IClientesRepository : IRepository<Entities.Cliente>
    {
    }
}
