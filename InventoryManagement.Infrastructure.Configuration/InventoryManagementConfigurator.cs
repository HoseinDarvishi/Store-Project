using InventoryManagement.Application;
using InventoryManagement.Application.Constracts.Inventory;
using InventoryManagement.Infrastructure.EFCore;
using InventoryManagement.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreQuery.Inventory;
using StoreQuery.Query;
using UtilityFreamwork.Infra;

namespace InventoryManagement.Infrastructure.Configuration
{
   public static class InventoryManagementConfigurator
   {
      public static void Configure(IServiceCollection services, string connectionString)
      {
         services.AddTransient<IInventoryApplication, InventoryApplication>();
         services.AddTransient<IInventoryRepository, InventoryRepository>();
         services.AddDbContext<InventoryContext>(x => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("ServiceHost")));

         //Query 
         services.AddTransient<IInventoryQuery, InventoryQuery>();

         //Permission
         services.AddTransient<IPermissionExposer, InventoryPermissionExposer>();
      }
   }
}
