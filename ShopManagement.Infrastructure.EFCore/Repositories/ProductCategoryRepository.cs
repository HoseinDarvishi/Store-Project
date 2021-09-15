using ShopManagement.Application.Constract.ProductCategory;
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

        public EditProductCategory GetDetails(long id)
        {
            return context.ProductCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                //Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Slug = x.Slug
            }).FirstOrDefault(x => x.Id == id);
        }

        public string GetSlug(long id)
        {
            return context.ProductCategories.Select(x => new { x.Id, x.Slug }).FirstOrDefault(x => x.Id == id).Slug;
        }
    }
}
