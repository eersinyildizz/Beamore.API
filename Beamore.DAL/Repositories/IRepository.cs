using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Beamore.DAL.Repositories
{
    /// <summary>
    /// This basic repository interface to generate database progress(CRUD)  
    /// </summary>
    /// <typeparam name="T">Database model</typeparam>
    public interface IRepository<T> where T : class
    {
        List<T> getAll();

        T FindById(int id);

        T add(T entity);

        T update(T entity);

        bool Delete(T entity);

        List<T> FindByExxpression(Expression<Func<T, bool>> predicate);

        T FindByExpBySingle(Expression<Func<T, bool>> predicate);

        void Save();

    }
}
