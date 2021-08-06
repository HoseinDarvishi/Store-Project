using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Constract.Product;
using ShopManagement.Application.Constract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication productApplication;
        private readonly IProductCategoryApplication categoryApplication;

        public IndexModel(IProductApplication productApplication, IProductCategoryApplication categoryApplication)
        {
            this.productApplication = productApplication;
            this.categoryApplication = categoryApplication;
        }

        public SelectList categories;
        public List<ProductVM> Products;
        public ProductSearchModel searchModel { get; set; }
        public EditProduct editProduct;

        public void OnGet(ProductSearchModel search)
        {
            categories = new SelectList(categoryApplication.GetSelectList(), "Id", "Name");
            Products = productApplication.Search(search);
        }

        public IActionResult OnGetCreate()
        {
            var product = new CreateProduct
            {
                categories = categoryApplication.GetSelectList()
            };
            return Partial("./Create", product);
        }

        public JsonResult OnPostCreate(CreateProduct product)
        {
            var result = productApplication.Create(product);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            editProduct = productApplication.GetDetails(id);
            editProduct.Categories = categoryApplication.GetSelectList();
            return Partial("./Edit", editProduct);
        }

        public JsonResult OnPostEdit(EditProduct product)
        {
            var result = productApplication.Edit(product);
            return new JsonResult(result);
        }

        public IActionResult OnGetNotInStock(long id)
        {
            productApplication.NotInStock(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetInStock(long id)
        {
            productApplication.InStock(id);
            return RedirectToPage("./Index");
        }
    }
}
