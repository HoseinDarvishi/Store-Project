using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Constract.Product;
using ShopManagement.Application.Constract.ProductCategory;
using UtilityFreamwork.Infra;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
   public class IndexModel : PageModel
   {
      private readonly IProductApplication productApplication;
      private readonly IArticleCategoryApplication categoryApplication;

      public IndexModel(IProductApplication productApplication, IArticleCategoryApplication categoryApplication)
      {
         this.productApplication = productApplication;
         this.categoryApplication = categoryApplication;
      }

      public SelectList categories;
      public List<ProductVM> Products;
      public ProductSearchModel searchModel { get; set; }
      public EditProduct editProduct;

      [NeedPermission(ShopPermissions.ListProducts)]
      public void OnGet(ProductSearchModel search)
      {
         categories = new SelectList(categoryApplication.GetSelectList(), "Id", "Name");
         Products = productApplication.Search(search);
      }

      [NeedPermission(ShopPermissions.CreateProduct)]
      public IActionResult OnGetCreate()
      {
         var product = new CreateProduct
         {
            categories = categoryApplication.GetSelectList()
         };
         return Partial("./Create", product);
      }

      [NeedPermission(ShopPermissions.CreateProduct)]
      public JsonResult OnPostCreate(CreateProduct product)
      {
         var result = productApplication.Create(product);
         return new JsonResult(result);
      }

      [NeedPermission(ShopPermissions.EditProduct)]
      public IActionResult OnGetEdit(long id)
      {
         editProduct = productApplication.GetDetails(id);
         editProduct.Categories = categoryApplication.GetSelectList();
         return Partial("./Edit", editProduct);
      }

      [NeedPermission(ShopPermissions.EditProduct)]
      public JsonResult OnPostEdit(EditProduct product)
      {
         var result = productApplication.Edit(product);
         return new JsonResult(result);
      }
   }
}
