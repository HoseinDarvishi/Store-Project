using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Constract.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;
using System.Linq;
using UtilityFreamwork.Application;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
    public class ProductRepository : GenericRepository<long, Product>, IProductRepository
    {
        private readonly ShopContext context;

        public ProductRepository(ShopContext context) : base(context)
        {
            this.context = context;
        }

        public EditProduct GetDetails(long id)
        {
            return context.Products.Select(x => new EditProduct
            {
                CategoryId = x.CategoryId,
                Code = x.Code,
                Description = x.Description,
                Id = x.Id,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Name = x.Name,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug
            })
            .FirstOrDefault(x => x.Id == id);
        }

        public List<ProductVM> GetProducts()
        {
            return context.Products.Include(x => x.Category).Select(x => new ProductVM
            {
                Name = x.Name,
                Id = x.Id
            })
            .ToList();
        }

        public Product GetProductWithCategory(long id)
        {
            return context.Products.Include(x=>x.Category).FirstOrDefault(x=>x.Id == id);
        }

        public List<ProductVM> Search(ProductSearchModel searchModel)
        {
            var query = context.Products.Include(x => x.Category).Select(x => new ProductVM
            {
                Category = x.Category.Name,
                Name = x.Name,
                CategoryId = x.CategoryId,
                Code = x.Code,
                CreationDate = x.CreationDate.ToFarsi(),
                Id = x.Id,
                Picture = x.Picture,
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
