using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreQuery.ProductCategory;

namespace ServiceHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        private readonly IProductCategoryQuery categoryQuery;
        public ProductCategoryQM Category { get; set; }

        public ProductCategoryModel(IProductCategoryQuery categoryQuery)
        {
            this.categoryQuery = categoryQuery;
        }

        public void OnGet(string id)
        {
            Category = categoryQuery.GetCategoryWithProducts(id);
        }
    }
}
