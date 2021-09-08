using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreQuery.Product;

namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {
        public string Value { get; set; }
        public List<ProductQM> Products { get; set; }

        private readonly IProductQuery productQuery;

        public SearchModel(IProductQuery productQuery)
        {
            this.productQuery = productQuery;
        }

        public void OnGet(string value)
        {
            Products = productQuery.Search(value);
            Value = value;
        }
    }
}
