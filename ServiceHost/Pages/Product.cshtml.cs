using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreQuery.Product;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductQuery productQuery;
        public ProductQM Product { get; set; }

        public ProductModel(IProductQuery productQuery)
        {
            this.productQuery = productQuery;
        }

        public void OnGet(string id)
        {
            Product = productQuery.GetProduct(id);
        }
    }
}
