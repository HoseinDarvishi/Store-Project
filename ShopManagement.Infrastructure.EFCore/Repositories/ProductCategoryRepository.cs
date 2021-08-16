using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
    public class ProductCategoryRepository : GenericRepository<long , ProductCategory> , IProductCategoryRepository
    {
        private readonly ShopContext context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            this.context = context;
        }

        public List<ProductCategory> Search(string name)
        {
            if (!string.IsNullOrWhiteSpace(name))
                return context.ProductCategories.Where(x => x.Name.Contains(name)).ToList();

            return context.ProductCategories.ToList();
        }
    }
}
