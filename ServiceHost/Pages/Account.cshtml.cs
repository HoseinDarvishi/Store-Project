using AccountManagement.Application.Constracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
   public class AccountModel : PageModel
   {
      private readonly IAccountApplication _accountApplication;

      public AccountModel(IAccountApplication accountApplication)
      {
         _accountApplication = accountApplication;
      }

      public void OnGet()
      {
      }

      //Login
      public IActionResult OnPostLogin(Login login)
      {
         var log = _accountApplication.Login(login);

         if (log.IsSuccedded)
            return RedirectToPage("/Index");

         TempData["Login"] = log.Message;
         return Page();
      }

      //LogOut
      public IActionResult OnGetLogout()
      {
         _accountApplication.Logout();
         return RedirectToPage("/Index");
      }

      //Register
      public IActionResult OnPostRegister(RegisterAccount command)
      {
         var res = _accountApplication.Register(command);
         TempData["Register"] = res.Message;
         return Page();
      }
   }
}
