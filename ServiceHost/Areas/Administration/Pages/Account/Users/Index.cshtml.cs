using System.Collections.Generic;
using AccountManagement.Application.Constracts.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Areas.Administration.Pages.Account.Users
{
   public class IndexModel : PageModel
   {
      private readonly IAccountApplication _accountApplication;

      public IndexModel(IAccountApplication accountApplication)
      {
         _accountApplication = accountApplication;
      }

      public AccountSearchModel searchModel;
      public List<AccountVM> users;

      public void OnGet(AccountSearchModel searchModel)
      {
         users = _accountApplication.Search(searchModel);
      }

      // Create
      public IActionResult OnGetCreate()
      {
         var create = new CreateAccount();
         return Partial("./Create" , create);
      }

      public IActionResult OnPostCreate(CreateAccount create)
      {
         var res = _accountApplication.Create(create);
         return new JsonResult(res);
      }

      //Edit
      public IActionResult OnGetEdit(long id)
      {
         var user = _accountApplication.GetDetails(id);
         return Partial("./Edit", user);
      }

      public IActionResult OnPostEdit(EditAccount account)
      {
         var res = _accountApplication.Edit(account);
         return new JsonResult(res);
      }

      //Change Password
      public IActionResult OnGetChangePassword(long id)
      {
         var pass = new ChangePassword();
         pass.Id = id;
         return Partial("./ChangePassword", pass);
      }

      public IActionResult OnPostChangePassword(ChangePassword changePassword)
      {
         var res = _accountApplication.ChangePassword(changePassword);
         return new JsonResult(res);
      }

      //Upgrade User
      public IActionResult OnGetUpgrade(long id)
      {
         var role = _accountApplication.GetRole(id);
         return Partial("./Upgrade" , role);
      }

      public IActionResult OnPostUpgrade(UpgradeRole role)
      {
         var res = _accountApplication.Upgrade(role);
         return new JsonResult(res);
      }
   }
}
