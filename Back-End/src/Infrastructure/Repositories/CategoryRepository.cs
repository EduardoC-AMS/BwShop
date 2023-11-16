using System.Reflection.Metadata;
using Domain.Models.CategoryModel;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class CategoryRepository : RepositoryBase <Category, Guid>, ICategoryRepository
    {
        
        public CategoryRepository(ApplicationDataContext applicationDataContext) : base(applicationDataContext)
        {
        }

        public void Delete(Category category)
        {
            
            _entity.Remove(category);
        }
    }
}