using AccountManagement.Application.Constracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using UtilityFreamwork.Infra;

namespace ServiceHost.Areas.Administration.Pages.Account.Roles
{
   public class CreateModel : PageModel
   {
      private readonly IRoleApplication _roleApplication;
      private readonly IEnumerable<IPermissionExposer> _permissionExposers;

      public CreateModel(IRoleApplication roleApplication , IEnumerable<IPermissionExposer> permissionExposers)
      {
         _roleApplication = roleApplication;
         _permissionExposers = permissionExposers;
      }

      public CreateRole Command { get; set; }
      public List<SelectListItem> Permissions;

      public void OnGet()
      {
      }

      public RedirectToPageResult OnPost(CreateRole Command)
      {
         _roleApplication.Create(Command);
         return RedirectToPage("./Index");
      }
   }
}
