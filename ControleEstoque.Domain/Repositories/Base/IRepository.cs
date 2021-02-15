using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ControleEstoque.Domain.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> ObterTodos(params string[] includes);
        T ObterUm(Expression<Func<T, bool>> predicate, params string[] includes);
        IQueryable<T> Obter(Expression<Func<T, bool>> predicate, params string[] includes);
        void Adicionar(T entidade);
        void Adicionar(IEnumerable<T> entities);
        void Atualizar(T entidade);
        void Atualizar(IEnumerable<T> entities);
        void Remover(T entidade);
        void Remover(IEnumerable<T> entities);
    }
}
