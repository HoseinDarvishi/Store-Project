using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Constract.Product;
using ShopManagement.Application.Constract.ProductPicture;
using UtilityFreamwork.Infra;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPictures
{
   public class IndexModel : PageModel
   {
      private readonly IProductApplication _productApplication;
      private readonly IProductPictureApplication _pictureApplication;

      public IndexModel(IProductApplication productApplication, IProductPictureApplication pictureApplication)
      {
         _productApplication = productApplication;
         _pictureApplication = pictureApplication;
      }

      public List<ProductPictureVM> ProductPictures;
      public ProductPictureSearchModel searchModel { get; set; }
      public EditProductPicture editProductPictures;
      public SelectList Products;

      [NeedPermission(ShopPermissions.ListProductPictures)]
      public void OnGet(ProductPictureSearchModel search)
      {
         Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
         ProductPictures = _pictureApplication.Search(search);
      }

      [NeedPermission(ShopPermissions.CreateProductPictures)]
      public IActionResult OnGetCreate()
      {
         var productPicture = new CreateProductPicture
         {
            Products = _productApplication.GetProducts()
         };
         return Partial("./Create", productPicture);
      }

      [NeedPermission(ShopPermissions.CreateProductPictures)]
      public JsonResult OnPostCreate(IFormFileCollection picture, IFormCollection infos)
      {
         var create = new CreateProductPicture
         {
            Picture = picture[0],
            PictureAlt = infos["PictureAlt"],
            PictureTitle = infos["PictureTitle"],
            ProductId = Convert.ToInt64(infos["ProductId"])
         };
         var result = _pictureApplication.Create(create);
         return new JsonResult(result);
      }

      [NeedPermission(ShopPermissions.EditProductPictures)]
      public IActionResult OnGetEdit(long id)
      {
         editProductPictures = _pictureApplication.GetDetail(id);
         editProductPictures.Products = _productApplication.GetProducts();

         return Partial("./Edit", editProductPictures);
      }

      [NeedPermission(ShopPermissions.EditProductPictures)]
      public JsonResult OnPostEdit(EditProductPicture product)
      {
         var result = _pictureApplication.Edit(product);
         return new JsonResult(result);
      }

      [NeedPermission(ShopPermissions.DeleteProductPictures)]
      public IActionResult OnGetRemove(long id)
      {
         _pictureApplication.Remove(id);
         return RedirectToPage("./index");
      }

      [NeedPermission(ShopPermissions.RestoreProductPictures)]
      public IActionResult OnGetRestore(long id)
      {
         _pictureApplication.Restore(id);
         return RedirectToPage("./index");
      }
   }
}
