using Microsoft.AspNetCore.Mvc;
using StoreQuery.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class LatestProductViewComponent : ViewComponent
    {
        private readonly IProductQuery productQuery;

        public LatestProductViewComponent(IProductQuery productQuery)
        {
            this.productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = productQuery.GetLatestProducts();
            return View("LatestProducts",products);
        }
    }
}
