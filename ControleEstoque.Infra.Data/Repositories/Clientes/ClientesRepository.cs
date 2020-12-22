using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Repositories.Clientes;
using ControleEstoque.Infra.Data.Context;
using ControleEstoque.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Infra.Data.Repositories.Clientes
{
    public class ClientesRepository : Repository<Cliente>, IClientesRepository
    {
        public ClientesRepository(ControleEstoqueContext context) : base(context)
        {
        }
    }
}
