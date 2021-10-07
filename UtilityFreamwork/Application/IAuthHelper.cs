using System.Collections.Generic;

namespace UtilityFreamwork.Application
{
   public interface IAuthHelper
   {
      void SignIn(AuthVM account);
      void SignOut();
      bool IsAuthenticated();
      string CurrentAccountRole();
      AuthVM CurrentAccountInfo();
      List<int> GetPermissionCodes();
   }
}
