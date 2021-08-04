using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constract.ProductCategory;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductCategories
{
    public class IndexModel : PageModel
    {
        private readonly IProductCategoryApplication categoryApplication;

        public IndexModel(IProductCategoryApplication categoryApplication)
        {
            this.categoryApplication = categoryApplication;
        }

        public List<ProductCategoryVM> categories;
        public ProductCategorySearchModel searchModel { get; set; }
        public EditProductCategory editCategory;

        public void OnGet(ProductCategorySearchModel search)
        {
            categories = categoryApplication.Search(search);
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

        public IActionResult OnGetEdit(long id)
        {
            editCategory = categoryApplication.GetBy(id);
            return Partial("./Edit", editCategory);
        } 

        public JsonResult OnPostEdit(EditProductCategory category)
        {
            var result = categoryApplication.Edit(category);
            return new JsonResult(result);
        }
    }
}
