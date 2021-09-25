using AccountManagement.Application;
using AccountManagement.Application.Constracts.Account;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Infrastructure.EFCore;
using AccountManagement.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Infrastructure.Configuration
{
   public class AccountManagementConfigurator
   {
      public static void Configure(IServiceCollection services , string connectionString)
      {
         services.AddTransient<IAccountApplication, AccountApplication>();
         services.AddTransient<IAccountRepository, AccountRepository>();

         services.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionString, b => b.MigrationsAssembly("ServiceHost")));
      }
   }
}
