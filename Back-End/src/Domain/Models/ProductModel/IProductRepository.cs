using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Data;
using Domain.Models.CategoryModel;

namespace Domain.Models.ProductModel
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        void Delete (Product product);
    }
}