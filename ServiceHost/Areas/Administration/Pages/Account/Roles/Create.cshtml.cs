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
      private readonly IEnumerable<IPermissionExposer> _exposers;

      public CreateModel(IRoleApplication roleApplication , IEnumerable<IPermissionExposer> permissionExposers)
      {
         _roleApplication = roleApplication;
         _exposers = permissionExposers;
      }

      public CreateRole Command { get; set; }
      public List<SelectListItem> Permissions;


      [NeedPermission(ShopPermissions.CreateRole)]
      public void OnGet()
      {
         // Get Permissions
         var permissions = new List<PermissionDto>();
         foreach (var exposer in _exposers)
         {
            var exposedPer = exposer.Expose();

            foreach (var (key, value) in exposedPer)
            {
               permissions.AddRange(value);

               var group = new SelectListGroup() { Name = key };

               foreach (var permission in value)
               {
                  var item = new SelectListItem(permission.Name, permission.Code.ToString())
                  {
                     Group = group
                  };

                  Permissions.Add(item);
               }
            }
         }
      }

      [NeedPermission(ShopPermissions.CreateRole)]
      public RedirectToPageResult OnPost(CreateRole Command)
      {
         _roleApplication.Create(Command);
         return RedirectToPage("./Index");
      }
   }
}
