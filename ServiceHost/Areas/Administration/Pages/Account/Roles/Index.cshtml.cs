using System.Collections.Generic;
using AccountManagement.Application.Constracts.Role;
using Microsoft.AspNetCore.Mvc;
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


      // Create
      public IActionResult OnGetCreate()
      {
         var create = new CreateRole();
         return Partial("./Create" , create);
      }

      public IActionResult OnPostCreate(CreateRole create)
      {
         var res = _roleApplication.Create(create);
         return new JsonResult(res);
      }


      //Edit
      public IActionResult OnGetEdit(sbyte id)
      {
         var user = _roleApplication.GetDetails(id);
         return Partial("./Edit", user);
      }

      public IActionResult OnPostEdit(EditRole role)
      {
         var res = _roleApplication.Edit(role);
         return new JsonResult(res);
      }
   }
}
