using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Test.Data
{
    public abstract class BaseTestDB
    {
          public BaseTestDB()
          {
            
          }
    }
    public class DbTest : IDisponsible{
    private readonly string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
    public ServiceProvider ServiceProvider {get; private set;}
    
    public DbTest(){
    var serviceCollection = new ServiceCollection();

     serviceCollection.AddDbContext<ApplicationDataContext>(0 =>,
     object.UseSqlite($"Data Source={dataBaseName}.db")),
     ServicesLifetime.Transient };
       
       ServicerProvider= serviceCollection.BuildServiceProvider();
       using (var context = ServicesProvider.GetService<ApplicationDataContext>())
     {
        context.Database.EnsureCreated();
     }

  

    public void Dispose(){
        using(var context = ServiceProvider.GetService)
    }
}
}
