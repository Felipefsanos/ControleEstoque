using ControleEstoque.Domain.Entities;
using ControleEstoque.Domain.Repositories.Telefones;
using ControleEstoque.Infra.Data.Context;
using ControleEstoque.Infra.Data.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace ControleEstoque.Infra.Data.Repositories.Telefones
{
    public class TelefonesRepository : Repository<Telefone>, ITelefonesRepository
    {
        public TelefonesRepository(ControleEstoqueContext context) : base(context)
        {
        }
    }
}
