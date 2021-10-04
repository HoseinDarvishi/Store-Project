using AccountManagement.Application.Constracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Account.Roles
{
   public class EditModel : PageModel
   {
      private readonly IRoleApplication _roleApplication;

      public EditModel(IRoleApplication roleApplication)
      {
         _roleApplication = roleApplication;
      }

      public EditRole command;

      public void OnGet(int id)
      {
         command = _roleApplication.GetDetails(id);
      }
      
      public RedirectToPageResult OnPost(EditRole command)
      {
         _roleApplication.Edit(command);
         return RedirectToPage("./Index");
      }
   }
}
