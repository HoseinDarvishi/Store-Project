using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountManagement.Infrastructure.EFCore
{
   public class AccountContext : DbContext
   {
      public DbSet<Account> Accounts { get; set; }

      public AccountContext(DbContextOptions<AccountContext> options) : base (options)
      { }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.ApplyConfigurationsFromAssembly(typeof(AccountMapping).Assembly);
         base.OnModelCreating(modelBuilder);
      }
   }
}
