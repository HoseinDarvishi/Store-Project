using AccountManagement.Application.Constracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using UtilityFreamwork.Infra;

namespace ServiceHost.Areas.Administration.Pages.Account.Roles
{
   public class EditModel : PageModel
   {
      private readonly IRoleApplication _roleApplication;
      private readonly IEnumerable<IPermissionExposer> _exposers;

      public EditModel(IRoleApplication roleApplication , IEnumerable<IPermissionExposer> exposers)
      {
         _roleApplication = roleApplication;
         _exposers = exposers;
      }

      public EditRole command;
      public List<SelectListItem> Permissions = new List<SelectListItem>();

      [NeedPermission(ShopPermissions.EditRole)]
      public void OnGet(int id)
      {
         command = _roleApplication.GetDetails(id);

         // Get Permissions
         var permissions = new List<PermissionDto>();
         foreach (var exposer in _exposers)
         {
            var exposedPer = exposer.Expose();

            foreach (var (key , value) in exposedPer)
            {
               permissions.AddRange(value);

               var group = new SelectListGroup() { Name = key };

               foreach (var permission in value)
               {
                  var item = new SelectListItem(permission.Name, permission.Code.ToString())
                  {
                     Group = group
                  };

                  if (command.MappedPermissions.Any(x=>x.Code == permission.Code))
                     item.Selected = true;

                  Permissions.Add(item);
               }
            }
         }

      }

      [NeedPermission(ShopPermissions.EditRole)]
      public RedirectToPageResult OnPost(EditRole command)
      {
         _roleApplication.Edit(command);
         return RedirectToPage("./Index");
      }
   }
}
