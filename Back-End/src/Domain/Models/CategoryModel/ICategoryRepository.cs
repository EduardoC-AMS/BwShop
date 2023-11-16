using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Core.Data;

namespace Domain.Models.CategoryModel
{
    public interface ICategoryRepository : IRepository<Category, Guid>
    {
        void Delete (Category category);

    }
}