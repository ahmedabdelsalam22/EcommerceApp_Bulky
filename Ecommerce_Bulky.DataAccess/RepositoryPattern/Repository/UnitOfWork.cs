using Ecommerce_Bulky.DataAccess.RepositoryPattern.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Bulky.DataAccess.RepositoryPattern.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            categoryRepository = new CategoryRepository(_context);
            productRepository = new ProductRepository(_context);
        }
        public ICategoryRepository categoryRepository { get; private set; }
        public IProductRepository productRepository { get; private set; }

        public async Task Save() 
        {
            await _context.SaveChangesAsync();
        }
    }
}
