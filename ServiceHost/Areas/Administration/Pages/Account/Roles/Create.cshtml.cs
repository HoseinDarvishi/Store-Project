using AccountManagement.Application.Constracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Account.Roles
{
   public class CreateModel : PageModel
   {
      private readonly IRoleApplication _roleApplication;

      public CreateModel(IRoleApplication roleApplication)
      {
         _roleApplication = roleApplication;
      }

      public CreateRole Command { get; set; }

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
