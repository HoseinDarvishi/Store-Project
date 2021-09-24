using AccountManagement.Application.Constracts.Account;
using System.Collections.Generic;
using UtilityFreamwork.Repository;

namespace AccountManagement.Domain.AccountAgg
{
   public interface IAccountRepository : IRepository<long , Account>
   {
      List<AccountVM> Search(AccountSearchModel command);
      EditAccount GetDetails(long id);
   }
}
