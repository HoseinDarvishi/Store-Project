using StoreQuery.ArticleCategory;
using StoreQuery.ProductCategory;
using System.Collections.Generic;

namespace StoreQuery.ModelHelper
{
    public class HeaderModel
    {
        public List<ArticleCategoryQM> ArticleCategories { get; set; }
        public List<ProductCategoryQM> ProductCategories { get; set; }
    }
}
