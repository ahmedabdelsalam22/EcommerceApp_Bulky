using Ecommerce_Bulky.DataAccess.RepositoryPattern.IRepository;
using EcommerceApp_Bulky.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Bulky.DataAccess.RepositoryPattern.Repository
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext Context) : base(Context)
        {
            _context = Context;
        }

        public void Update(Category category)
        {
            _context.Update(category);
        }
    }
}
