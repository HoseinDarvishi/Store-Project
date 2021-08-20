using ShopManagement.Application.Constract.Product;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public interface IProductRepository : IGenericRepository<long , Product> 
    {
        EditProduct GetDetails(long id);
        Product GetProductWithCategory(long id);
        List<ProductVM> GetProducts();
        List<ProductVM> Search(ProductSearchModel searchModel);
    }
}
