using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory category);

        ProductCategory GetBy(long id);

        List<ProductCategory> GetAll();

        bool IsExists(Expression<Func<ProductCategory , bool>> expression);

        void Save();
    }
}
