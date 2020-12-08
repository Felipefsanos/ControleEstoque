using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ControleEstoque.Domain.Repositories.Base
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> ObterTodos();
        T ObterUm(Expression<Func<T, bool>> filtro);
        IEnumerable<T> Obter(Expression<Func<T, bool>> filtro);
        void Adicionar(T entidade);
        void Atualizar(T entidade);
        void Remover(T entidade);
    }
}
