using System;
using System.Collections.Generic;
using DiscountManagement.Application.Constracts.CustomerDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Constract.Product;
using UtilityFreamwork.Infra;

namespace ServiceHost.Areas.Administration.Pages.Discounts.CustomerDiscount
{
   public class IndexModel : PageModel
   {
      private readonly IProductApplication productApplication;
      private readonly ICustomerDiscountApplication customerApplication;

      public IndexModel(IProductApplication productApplication, ICustomerDiscountApplication customerApplication)
      {
         this.productApplication = productApplication;
         this.customerApplication = customerApplication;
      }

      public SelectList Products;
      public List<CustomerDiscountVM> Discounts;
      public CustomerDiscountSearchModel searchModel { get; set; }
      public EditCustomerDiscount editProduct;

      [NeedPermission(ShopPermissions.ListDiscount)]
      public void OnGet(CustomerDiscountSearchModel search)
      {
         Products = new SelectList(productApplication.GetProducts(), "Id", "Name");
         Discounts = customerApplication.Search(search);
      }

      [NeedPermission(ShopPermissions.DefineDiscount)]
      public IActionResult OnGetCreate()
      {
         var createDiscount = new CreateCustomerDiscount()
         {
            Products = productApplication.GetProducts()
         };
         return Partial("./Create", createDiscount);
      }
      [NeedPermission(ShopPermissions.DefineDiscount)]
      public JsonResult OnPostCreate(CreateCustomerDiscount discount)
      {
         var result = customerApplication.Create(discount);
         return new JsonResult(result);
      }
      [NeedPermission(ShopPermissions.EditDiscount)]
      public IActionResult OnGetEdit(long id)
      {
         editProduct = customerApplication.GetDetail(id);
         editProduct.Products = productApplication.GetProducts();
         return Partial("./Edit", editProduct);
      }
      [NeedPermission(ShopPermissions.EditDiscount)]
      public JsonResult OnPostEdit(EditCustomerDiscount editCustomer)
      {
         var result = customerApplication.Edit(editCustomer);
         return new JsonResult(result);
      }
      [NeedPermission(ShopPermissions.DeActiveDiscount)]
      public IActionResult OnGetDeActive(long id)
      {
         customerApplication.DeActive(id);
         return RedirectToPage("./Index");
      }
      [NeedPermission(ShopPermissions.ActiveDiscount)]
      public IActionResult OnGetActive(long id)
      {
         customerApplication.Active(id);
         return RedirectToPage("./Index");
      }
   }
}
