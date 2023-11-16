using System.Reflection.Metadata;
using Domain.Models.CategoryModel;
using Domain.Models.ProductModel;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class ProductRepository : RepositoryBase <Product, Guid>, IProductRepository
    {
        
        public ProductRepository(ApplicationDataContext applicationDataContext) : base(applicationDataContext)
        {
        }

        public void Delete(Product product)
        {
            
            _entity.Remove(product);
        }
    }
}