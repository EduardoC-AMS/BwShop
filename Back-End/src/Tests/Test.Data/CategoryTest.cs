using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models.CategoryModel;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Data
{
    public class CategoryTest : BaseTestDB, IClassFixture<Category>
    {
        private ServiceProvider _ServiceProvide;

        public CategoryTest(DbTest dbTest)
        {
            _ServiceProvide = dbTest.ServiceProvider;
        }
    }
    
}