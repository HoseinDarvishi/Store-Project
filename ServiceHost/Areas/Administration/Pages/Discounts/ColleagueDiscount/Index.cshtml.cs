using System.Collections.Generic;
using DiscountManagement.Application.Constracts.ColleagueDiscount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Constract.Product;
using UtilityFreamwork.Infra;

namespace ServiceHost.Areas.Administration.Pages.Discounts.ColleagueDiscount
{
   public class IndexModel : PageModel
   {
      private readonly IProductApplication productApplication;
      private readonly IColleagueDiscountApplication colleagueApplication;

      public IndexModel(IProductApplication productApplication, IColleagueDiscountApplication colleagueApplication)
      {
         this.productApplication = productApplication;
         this.colleagueApplication = colleagueApplication;
      }

      public List<ColleagueDiscountVM> Discounts;
      public ColleagueDiscountSearchModel searchModel { get; set; }
      public SelectList Products { get; set; }

      [NeedPermission(ShopPermissions.ListDiscount)]
      public void OnGet(ColleagueDiscountSearchModel search)
      {
         Products = new SelectList(productApplication.GetProducts(), "Id", "Name");
         Discounts = colleagueApplication.Search(search);
      }

      [NeedPermission(ShopPermissions.DefineDiscount)]
      public IActionResult OnGetCreate()
      {
         var createDiscount = new CreateColleagueDiscount()
         {
            Products = productApplication.GetProducts()
         };
         return Partial("./Create", createDiscount);
      }

      [NeedPermission(ShopPermissions.DefineDiscount)]
      public JsonResult OnPostCreate(CreateColleagueDiscount discount)
      {
         var result = colleagueApplication.Create(discount);
         return new JsonResult(result);
      }

      [NeedPermission(ShopPermissions.EditDiscount)]
      public IActionResult OnGetEdit(long id)
      {
         var editDiscount = colleagueApplication.GetDetail(id);
         editDiscount.Products = productApplication.GetProducts();
         return Partial("./Edit", editDiscount);
      }

      [NeedPermission(ShopPermissions.EditDiscount)]
      public JsonResult OnPostEdit(EditColleagueDiscount editDiscount)
      {
         var result = colleagueApplication.Edit(editDiscount);
         return new JsonResult(result);
      }

      [NeedPermission(ShopPermissions.DeActiveDiscount)]
      public IActionResult OnGetDeActive(long id)
      {
         colleagueApplication.DeActive(id);
         return RedirectToPage("./Index");
      }

      [NeedPermission(ShopPermissions.ActiveDiscount)]
      public IActionResult OnGetActive(long id)
      {
         colleagueApplication.Active(id);
         return RedirectToPage("./Index");
      }
   }
}
