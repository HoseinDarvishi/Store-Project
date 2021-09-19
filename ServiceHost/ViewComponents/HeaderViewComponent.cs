using Microsoft.AspNetCore.Mvc;
using StoreQuery.Article;
using StoreQuery.ModelHelper;
using StoreQuery.ProductCategory;

namespace ServiceHost.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        private readonly IArticleQuery _articleCategoryQuery;
        private readonly IProductCategoryQuery _productCategoryQuery;

        public HeaderViewComponent(IArticleQuery articleCategoryQuery, IProductCategoryQuery productCategoryQuery)
        {
            _articleCategoryQuery = articleCategoryQuery;
            _productCategoryQuery = productCategoryQuery;
        }


        public IViewComponentResult Invoke()
        {
            var model = new HeaderModel
            {
                ProductCategories = _productCategoryQuery.GetCategoriesAsShort(),
                ArticleCategories = _articleCategoryQuery.GetCategoriesAsShort()
            };
            return View("Header" , model);
        }
    }
}
