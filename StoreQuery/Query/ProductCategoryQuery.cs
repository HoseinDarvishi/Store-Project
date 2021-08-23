using DiscountManagement.Infrastructure;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;
using StoreQuery.Product;
using StoreQuery.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilityFreamwork.Application;

namespace StoreQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext context;
        private readonly InventoryContext invContext;
        private readonly DiscountContext disContext;

        public ProductCategoryQuery(InventoryContext invContext , ShopContext context , DiscountContext discountContext)
        {
            this.invContext = invContext;
            this.context = context;
            this.disContext = discountContext;
        }

        public List<ProductCategoryQM> GetCategories()
        {
            return context.ProductCategories
                .Select(x => new ProductCategoryQM
                { 
                    Id = x.Id,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug
                })
                .ToList();
        }

        public List<ProductCategoryQM> GetCategoriesWithProducts()
        {
            var invs = invContext.Inventories.Select(x => new { x.ProductId, x.Price }).ToList();
            var discounts = disContext.CustomerDiscounts.Where(x => x.IsActive).Select(x => new { x.ProductId, x.DiscountPercent }).ToList();
            var categories = context.ProductCategories
                .Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQM
                {
                   Id = x.Id,
                   Name = x.Name,
                   Picture = x.Picture,
                   PictureTitle = x.PictureTitle,
                   PictureAlt = x.PictureAlt,
                   Slug = x.Slug,
                   Products = MapProducts(x.Products)
                })
                .ToList();

            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {
                    product.Price = invs.FirstOrDefault(x => x.ProductId == product.Id)?.Price.ToMoney();
                }
            }

            return categories;
        }

        private static List<ProductQM> MapProducts(List<ShopManagement.Domain.ProductAgg.Product> products)
        {
            return products.Select(x => new ProductQM
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category.Name,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
            })
            .ToList();
        }
    }
}
