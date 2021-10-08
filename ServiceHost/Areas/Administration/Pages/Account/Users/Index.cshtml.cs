using System.Collections.Generic;
using AccountManagement.Application.Constracts.Account;
using AccountManagement.Application.Constracts.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UtilityFreamwork.Infra;

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

      [NeedPermission(ShopPermissions.ListAccounts)]
      public void OnGet(AccountSearchModel searchModel)
      {
         roles = new SelectList(_roleApplication.List(), "Id", "Name");
         users = _accountApplication.Search(searchModel);
      }

      // Create
      [NeedPermission(ShopPermissions.CreateAccount)]
      public IActionResult OnGetCreate()
      {
         var create = new RegisterAccount();
         create.Roles = _roleApplication.List();
         return Partial("./Create" , create);
      }
      [NeedPermission(ShopPermissions.CreateAccount)]
      public IActionResult OnPostCreate(RegisterAccount create)
      {
         var res = _accountApplication.Register(create);
         return new JsonResult(res);
      }

      //Edit
      [NeedPermission(ShopPermissions.EditAccount)]
      public IActionResult OnGetEdit(long id)
      {
         var user = _accountApplication.GetDetails(id);
         user.Roles = _roleApplication.List();
         return Partial("./Edit", user);
      }

      [NeedPermission(ShopPermissions.EditAccount)]
      public IActionResult OnPostEdit(EditAccount account)
      {
         var res = _accountApplication.Edit(account);
         return new JsonResult(res);
      }

      //Change Password
      [NeedPermission(ShopPermissions.ChangePasswordAccount)]
      public IActionResult OnGetChangePassword(long id)
      {
         var pass = new ChangePassword();
         pass.Id = id;
         return Partial("./ChangePassword", pass);
      }

      [NeedPermission(ShopPermissions.ChangePasswordAccount)]
      public IActionResult OnPostChangePassword(ChangePassword changePassword)
      {
         var res = _accountApplication.ChangePassword(changePassword);
         return new JsonResult(res);
      }
   }
}
