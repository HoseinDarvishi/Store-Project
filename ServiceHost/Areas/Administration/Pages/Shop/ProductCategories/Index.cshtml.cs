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

        public void OnGet(ProductCategorySearchModel search)
        {
            //categories = categoryApplication.Search(search);
        }
    }
}
