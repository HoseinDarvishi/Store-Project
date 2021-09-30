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

      public Account GetBy(string username)
      {
         return _context.Accounts.FirstOrDefault(x => x.Username == username);
      }

      public EditAccount GetDetails(long id)
      {
         return _context.Accounts.Include(x=>x.Role).Select(x => new EditAccount
         {
            Id = x.Id,
            Fullname = x.Fullname,
            Mobile = x.Mobile,
            Username = x.Username,
            RoleId = x.RoleId,
            RoleName = x.Role.Name,
            PicturePath = x.Picture,
            SignInDate = x.CreationDate.ToFarsi()
         })
            .FirstOrDefault(x => x.Id == id);
      }

      public List<AccountVM> Search(AccountSearchModel command)
      {
         var query = _context.Accounts
            .Include(x=>x.Role)
            .Select(x => new AccountVM 
            {
               Id = x.Id,
               Fullname = x.Fullname,
               Username = x.Username,
               Mobile = x.Mobile,
               Picture = x.Picture,
               SignInDate = x.CreationDate.ToFarsi(),
               RoleId = x.RoleId,
               RoleName = x.Role.Name
            })
            .AsNoTracking();

         if (!string.IsNullOrWhiteSpace(command.Fullname))
            query = query.Where(x => x.Fullname.Contains(command.Fullname));

         if (!string.IsNullOrWhiteSpace(command.Mobile))
            query = query.Where(x => x.Mobile.Contains(command.Mobile));

         if (!string.IsNullOrWhiteSpace(command.Username))
            query = query.Where(x => x.Username.Contains(command.Username));

         if (command.RoleId > 0)
            query = query.Where(x => x.RoleId == command.RoleId);

         return query.OrderByDescending(x => x.Id).ToList();
      }
   }
}
