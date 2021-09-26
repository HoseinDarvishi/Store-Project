using AccountManagement.Application.Constracts.Account;
using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using UtilityFreamwork.Application;
using UtilityFreamwork.Repository;

namespace AccountManagement.Infrastructure.EFCore.Repositories
{
   public class AccountRepository : Repository<long, Account>, IAccountRepository
   {
      private readonly AccountContext _context;

      public AccountRepository(AccountContext context) : base(context)
      {
         _context = context;
      }

      public EditAccount GetDetails(long id)
      {
         return _context.Accounts.Select(x => new EditAccount
         {
            Id = x.Id,
            Fullname = x.Fullname,
            Mobile = x.Mobile,
            Username = x.Username,
            Role = x.Role,
            PicturePath = x.Picture,
            SignInDate = x.CreationDate.ToFarsi()
         })
            .FirstOrDefault(x => x.Id == id);
      }

      public UpgradeRole GetRole(long id)
      {
         return _context.Accounts
            .Select(x => new UpgradeRole
            {
               Id = x.Id,
               Role = x.Role
            })
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);
      }

      public List<AccountVM> Search(AccountSearchModel command)
      {
         var query = _context.Accounts
            .Select(x => new AccountVM 
            {
               Id = x.Id,
               Fullname = x.Fullname,
               Username = x.Username,
               Mobile = x.Mobile,
               Picture = x.Picture,
               SignInDate = x.CreationDate.ToFarsi(),
               Role = x.Role
            })
            .AsNoTracking();

         if (!string.IsNullOrWhiteSpace(command.Fullname))
            query = query.Where(x => x.Fullname.Contains(command.Fullname));

         if (!string.IsNullOrWhiteSpace(command.Mobile))
            query = query.Where(x => x.Mobile.Contains(command.Mobile));

         if (!string.IsNullOrWhiteSpace(command.Username))
            query = query.Where(x => x.Username.Contains(command.Username));

         if (command.Role > 0)
            query = query.Where(x => x.Role == command.Role);

         return query.OrderByDescending(x => x.Id).ToList();
      }
   }
}
