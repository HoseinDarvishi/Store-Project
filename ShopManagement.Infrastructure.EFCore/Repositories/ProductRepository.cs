using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Constract.Product;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
    public class ProductRepository : GenericRepository<long, Product>, IProductRepository
    {
        private readonly Context context;

        public ProductRepository(Context context) : base(context)
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
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Price = x.Price,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug
            })
            .FirstOrDefault(x => x.Id == id);
        }

        public List<ProductVM> GetProducts()
        {
            return context.Products.Include(x => x.Category).Select(x => new ProductVM
            {
                Category = x.Category.Name,
                Name = x.Name,
                CategoryId = x.CategoryId,
                Code = x.Code,
                CreationDate = x.CreationDate.ToString(),
                Id = x.Id,
                Picture = x.Picture,
                Price = x.Price,
                IsInStock = x.IsInStock
            })
            .ToList();
        }

        public Product GetProductWithCategory(long id)
        {
            return context.Products.Find(id);
        }

        public void InStock(long id)
        {
            context.Products.Find(id).InStock();
            Save();
        }

        public void NotInStock(long id)
        {
            context.Products.Find(id).NoStock();
            Save();
        }

        public List<ProductVM> Search(ProductSearchModel searchModel)
        {
            var query = context.Products.Include(x => x.Category).Select(x => new ProductVM
            {
                Category = x.Category.Name,
                Name = x.Name,
                CategoryId = x.CategoryId,
                Code = x.Code,
                CreationDate = x.CreationDate.ToString(),
                Id = x.Id,
                Picture = x.Picture,
                Price = x.Price,
                IsInStock = x.IsInStock
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
