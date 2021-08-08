using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Constract.Product;
using ShopManagement.Application.Constract.ProductPicture;

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

        public void OnGet(ProductPictureSearchModel search)
        {
            Products = new SelectList(_productApplication.GetProducts() , "Id" , "Name");
            ProductPictures = _pictureApplication.Search(search);
        }

        public IActionResult OnGetCreate()
        {
            var productPicture = new CreateProductPicture
            {
                Products = _productApplication.GetProducts()
            };
            return Partial("./Create", productPicture);
        }

        public JsonResult OnPostCreate(IFormCollection form)
        {
            CreateProductPicture pic = new CreateProductPicture();
            pic.Picture = form["Picture"];
            pic.PictureAlt = form["PictureAlt"];
            pic.PictureTitle = form["PictureTitle"];
            pic.ProductId = Convert.ToInt64(form["ProductId"]);

            var result = _pictureApplication.Create(pic);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            editProductPictures = _pictureApplication.GetDetail(id);
            editProductPictures.Products = _productApplication.GetProducts();

            return Partial("./Edit", editProductPictures);
        }

        public JsonResult OnPostEdit(EditProductPicture product)
        {
            var result = _pictureApplication.Edit(product);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            _pictureApplication.Remove(id);
            return RedirectToPage("./index");
        }

        public IActionResult OnGetRestore(long id)
        {
            _pictureApplication.Restore(id);
            return RedirectToPage("./index");
        }
    }
}
