﻿using Ecommerce_Bulky.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Bulky.DataAccess.RepositoryPattern.IRepository
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        void Update(Product product);
    }
}
