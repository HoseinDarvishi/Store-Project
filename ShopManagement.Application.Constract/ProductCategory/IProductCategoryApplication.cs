using System;
using System.Collections.Generic;
using System.Text;
using UtilityFreamwork.Application;

namespace ShopManagement.Application.Constract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        GenerateResult Create(CreateProductCategory category);

        GenerateResult Edit(EditProductCategory category);

        List<ProductCategoryVM> Search(ProductCategorySearchModel searchModel);

        EditProductCategory GetBy(long id);
    }
}
