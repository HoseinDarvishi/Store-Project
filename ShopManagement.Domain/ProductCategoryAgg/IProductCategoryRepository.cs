using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory category);

        ProductCategory GetBy(long id);

        List<ProductCategory> GetAll();
    }
}
