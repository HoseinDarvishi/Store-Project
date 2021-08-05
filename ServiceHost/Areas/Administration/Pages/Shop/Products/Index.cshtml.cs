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
        //public EditProductCategory editCategory;

        public void OnGet(ProductSearchModel search)
        {
            categories = new SelectList(categoryApplication.GetSelectList(), "Id", "Name");
            Products = productApplication.Search(search);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create" , new CreateProductCategory());
        }

        public JsonResult OnPostCreate(CreateProductCategory category)
        {
            var result = categoryApplication.Create(category);
            return new JsonResult(result);
        }

        //public IActionResult OnGetEdit(long id)
        //{
        //    editCategory = categoryApplication.GetBy(id);
        //    return Partial("./Edit", editCategory);
        //} 

        //public JsonResult OnPostEdit(EditProductCategory category)
        //{
        //    var result = categoryApplication.Edit(category);
        //    return new JsonResult(result);
        //}
    }
}
