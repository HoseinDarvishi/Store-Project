using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constract.Product;
using ShopManagement.Application.Constract.ProductCategory;
using UtilityFreamwork.Infra;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
   public class IndexModel : PageModel
   {
      private readonly IArticleCategoryApplication categoryApplication;

      public IndexModel(IArticleCategoryApplication categoryApplication)
      {
         this.categoryApplication = categoryApplication;
      }

      public List<ProductCategoryVM> categories;
      public ProductSearchModel searchModel { get; set; }
      public EditProductCategory editCategory;

      [NeedPermission(ShopPermissions.ListProductCategories)]
      public void OnGet(ProductCategorySearchModel search)
      {
         categories = categoryApplication.Search(search);
      }

      [NeedPermission(ShopPermissions.CreateProductCategory)]
      public IActionResult OnGetCreate()
      {
         return Partial("./Create", new CreateProductCategory());
      }

      [NeedPermission(ShopPermissions.CreateProductCategory)]
      public JsonResult OnPostCreate(CreateProductCategory category)
      {
         var result = categoryApplication.Create(category);
         return new JsonResult(result);
      }

      [NeedPermission(ShopPermissions.EditProductCategory)]
      public IActionResult OnGetEdit(long id)
      {
         editCategory = categoryApplication.GetBy(id);
         return Partial("./Edit", editCategory);
      }

      [NeedPermission(ShopPermissions.EditProductCategory)]
      public JsonResult OnPostEdit(EditProductCategory category)
      {
         var result = categoryApplication.Edit(category);
         return new JsonResult(result);
      }
   }
}
