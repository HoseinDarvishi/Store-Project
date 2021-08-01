using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Application.Constract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        void Create(CreateProductCategory category);

        void Edit(EditProductCategory category);

        List<ProductCategoryVM> Search(ProductCategorySearchModel searchModel);

        ShopManagement.Domain.ProductCategoryAgg.ProductCategory GetBy(long id);
    }
}
