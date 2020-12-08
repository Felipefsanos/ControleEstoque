using ControleEstoque.Domain.Repositories.Base;
using ControleEstoque.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ControleEstoque.Infra.Data.Repositories.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ControleEstoqueContext context;
        public Repository(ControleEstoqueContext context)
        {
            this.context = context;
        }

        public void Adicionar(T entity)
        {
            context.Add(entity);
        }

        public void Remover(T entity)
        {
            context.Remove(entity);
        }

        public IEnumerable<T> Obter(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).ToList();
        }

        public IEnumerable<T> ObterTodos()
        {
            return context.Set<T>().ToList();
        }

        public T Obter(int id)
        {
            return context.Set<T>().Find(id);
        }

        public T ObterUm(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate).FirstOrDefault();
        }

        public void Atualizar(T entity)
        {
            context.Update(entity);
        }
    }
}
