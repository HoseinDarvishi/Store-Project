using Microsoft.AspNetCore.Mvc;
using StoreQuery.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class ProductCategoryViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery categoryQuery;

        public ProductCategoryViewComponent(IProductCategoryQuery categoryQuery)
        {
            this.categoryQuery = categoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var cats = categoryQuery.GetCategories();
            return View("ProductCategories" , cats);
        }
    }
}
