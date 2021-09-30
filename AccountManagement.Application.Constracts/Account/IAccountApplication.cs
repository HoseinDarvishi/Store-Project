using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace AccountManagement.Application.Constracts.Account
{
   public interface IAccountApplication
   {
      GenerateResult Register(RegisterAccount command);
      GenerateResult Edit(EditAccount command);
      GenerateResult ChangePassword(ChangePassword command);
      GenerateResult ChangeUserName(ChangeUserName command);
      GenerateResult Login(Login command);
      List<AccountVM> Search(AccountSearchModel command);
      EditAccount GetDetails(long id);
      void Logout();
   }
}
