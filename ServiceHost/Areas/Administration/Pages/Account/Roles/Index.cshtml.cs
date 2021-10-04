using System.Collections.Generic;
using AccountManagement.Application.Constracts.Role;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Account.Roles
{
   public class IndexModel : PageModel
   {
      private readonly IRoleApplication _roleApplication;

      public IndexModel(IRoleApplication roleApplication)
      {
         _roleApplication = roleApplication;
      }

      public List<EditRole> roles;

      public void OnGet()
      {
         roles = _roleApplication.List();
      }
   }
}
