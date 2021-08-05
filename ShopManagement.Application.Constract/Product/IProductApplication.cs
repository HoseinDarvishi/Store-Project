using System;
using System.Collections.Generic;
using System.Text;
using UtilityFreamwork.Application;

namespace ShopManagement.Application.Constract.Product
{
    public interface IProductApplication
    {
        GenerateResult Create(CreateProduct command);
        GenerateResult Edit(EditProduct command);
        EditProduct GetDetails(long id);
        List<ProductVM> GetProducts();
        List<ProductVM> Search(ProductSearchModel searchModel);
    }
}
