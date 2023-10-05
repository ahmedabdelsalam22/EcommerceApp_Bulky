using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Bulky.DataAccess.RepositoryPattern.IRepository
{
    public interface IGenericRepository<T>  where T:class
    {
        IEnumerable<T> GetAllAsync(bool tracked = true);
        T GetByIdAsync(Expression<Func<T,bool>>? fliter=null , bool tracked=true);
        void CreateAsync(T entity);
        void Remove(T entity);

    }
}
