using ControleEstoque.Domain.Repositories.Base;
using ControleEstoque.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
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
            context.Set<T>().Add(entity);
        }

        public void Adicionar(IEnumerable<T> entities)
        {
            context.Set<T>().AddRange(entities);
        }

        public void Remover(T entity)
        {
            context.Set<T>().Remove(entity);
        }

        public void Remover(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
        }

        public void Atualizar(IEnumerable<T> entities)
        {
            context.Set<T>().UpdateRange(entities);
        }

        public void Atualizar(T entity)
        {
            context.Set<T>().Update(entity);
        }

        public T ObterUm(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            return context.GetDbSetWithIncludes<T>(includes).FirstOrDefault(predicate);
        }

        public IQueryable<T> Obter(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            return context.GetDbSetWithIncludes<T>(includes).Where(predicate);
        }

        public IQueryable<T> ObterTodos(params string[] includes)
        {
            return context.GetDbSetWithIncludes<T>(includes);
        }
    }
}
