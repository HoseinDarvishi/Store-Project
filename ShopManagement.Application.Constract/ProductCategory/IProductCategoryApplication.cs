using ShopManagement.Application.Constract.ProductCategory;
using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace ShopManagement.Application.Constract.ProductCategory
{
    public interface IProductCategoryApplication
    {
        GenerateResult Create(CreateProductCategory category);

        GenerateResult Edit(EditProductCategory category);

        List<ProductCategoryVM> Search(ProductCategorySearchModel searchModel);

        EditProductCategory GetBy(long id);

        List<ProductCategoryVM> GetSelectList();
    }
}
