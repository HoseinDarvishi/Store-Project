using System.Collections.Generic;
using AccountManagement.Application.Constracts.Account;
using AccountManagement.Application.Constracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Account.Users
{
   public class IndexModel : PageModel
   {
      private readonly IAccountApplication _accountApplication;
      private readonly IRoleApplication _roleApplication;

      public IndexModel(IAccountApplication accountApplication , IRoleApplication roleApplication)
      {
         _accountApplication = accountApplication;
         _roleApplication = roleApplication;
      }

      public AccountSearchModel searchModel;
      public List<AccountVM> users;
      public SelectList roles;

      public void OnGet(AccountSearchModel searchModel)
      {
         roles = new SelectList(_roleApplication.List(), "Id", "Name");
         users = _accountApplication.Search(searchModel);
      }

      // Create
      public IActionResult OnGetCreate()
      {
         var create = new CreateAccount();
         create.Roles = _roleApplication.List();
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
         user.Roles = _roleApplication.List();
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
   }
}
