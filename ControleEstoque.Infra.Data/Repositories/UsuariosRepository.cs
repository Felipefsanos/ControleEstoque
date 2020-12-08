using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Repositories;
using ControleEstoque.Infra.Data.Context;
using ControleEstoque.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Infra.Data.Repositories
{
    public class UsuariosRepository : Repository<Usuario>, IUsuariosRepository
    {
        public UsuariosRepository(ControleEstoqueContext context) : base(context)
        {
        }
    }
}
