using AccountManagement.Application;
using AccountManagement.Application.Constracts.Account;
using AccountManagement.Application.Constracts.Role;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Infrastructure.EFCore;
using AccountManagement.Infrastructure.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using UtilityFreamwork.Infra;

namespace AccountManagement.Infrastructure.Configuration
{
   public class AccountManagementConfigurator
   {
      public static void Configure(IServiceCollection services , string connectionString)
      {
         services.AddTransient<IAccountApplication, AccountApplication>();
         services.AddTransient<IAccountRepository, AccountRepository>();

         services.AddTransient<IRoleApplication, RoleApplication>();
         services.AddTransient<IRoleRepository, RoleRepository>();

         services.AddTransient<IPermissionExposer, AccountPermissionExposer>();

         services.AddDbContext<AccountContext>(x => x.UseSqlServer(connectionString , b=> b.MigrationsAssembly("ServiceHost")));
      }
   }
}
