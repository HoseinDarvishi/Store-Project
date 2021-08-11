using System.Collections.Generic;

namespace StoreQuery.ProductCategory
{
    public interface IProductCategoryQuery
    {
        List<ProductCategoryQM> GetCategories();
    }
}
