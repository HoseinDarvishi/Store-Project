using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IGenericRepository<long , ProductCategory>
    {
        List<ProductCategory> Search(string name);
    }
}
