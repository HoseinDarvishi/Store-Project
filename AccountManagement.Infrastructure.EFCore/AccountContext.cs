using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using AccountManagement.Infrastructure.EFCore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore
{
   public class AccountContext : DbContext
   {
      public DbSet<Account> Accounts { get; set; }
      public DbSet<Role> Roles { get; set; }

      public AccountContext(DbContextOptions<AccountContext> options) : base (options)
      { }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(typeof(RoleMapping).Assembly);
         
         base.OnModelCreating(modelBuilder);
      }
   }
}
