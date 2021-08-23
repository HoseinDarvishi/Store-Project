using Microsoft.AspNetCore.Mvc;
using StoreQuery.ProductCategory;

namespace ServiceHost.ViewComponents
{
    public class CategoryWithProductSliderViewComponent : ViewComponent
    {
        private readonly IProductCategoryQuery query;

        public CategoryWithProductSliderViewComponent(IProductCategoryQuery query)
        {
            this.query = query;
        }

        public IViewComponentResult Invoke()
        {
            var catsWithPros = query.GetCategoriesWithProducts();
            return View("CategoryWithProductsSlider" , catsWithPros);
        }
    }
}
