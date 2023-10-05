using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Bulky.DataAccess.RepositoryPattern.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository categoryRepository { get; }
    }
}
