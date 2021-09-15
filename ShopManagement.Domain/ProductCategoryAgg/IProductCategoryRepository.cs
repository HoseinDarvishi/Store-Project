using ShopManagement.Application.Constract.ProductCategory;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository : IGenericRepository<long , ProductCategory>
    {
        List<ProductCategory> Search(string name);
        EditProductCategory GetDetails(long id);
    }
}
