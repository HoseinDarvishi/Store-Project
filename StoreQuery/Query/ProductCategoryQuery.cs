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

        public List<ProductCategoryQM> GetCategoriesAsShort()
        {
            return context.ProductCategories
                .Select(x => new ProductCategoryQM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Slug = x.Slug
                })
                .ToList();
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
                   Products = MapProducts(x.Products),
                })
                .ToList();

            foreach (var category in categories)
            {
                foreach (var product in category.Products)
                {

                    var inv = invs.FirstOrDefault(x => x.ProductId == product.Id);
                    if (inv != null)
                    {
                        product.Price = inv.Price;
                        product.PriceString = inv.Price.ToMoney();
                    }

                    var disc = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    if (disc != null)
                    {
                        product.Discount = disc.DiscountPercent;
                        var discountw = (product.Price * product.Discount) / 100;
                        product.PriceWithDiscount = (product.Price - discountw).ToMoney();
                        product.HasDiscount = product.Discount > 0;
                    }
                }
            }

            return categories;
        }

        public ProductCategoryQM GetCategoryWithProducts(string slug)
        {
            var invs = invContext.Inventories.Select(x => new { x.ProductId, x.Price }).ToList();
            var discounts = disContext.CustomerDiscounts.Where(x => x.IsActive).Select(x => new { x.ProductId, x.DiscountPercent , x.EndDate}).ToList();

            var category = context.ProductCategories
                .Include(x => x.Products)
                .ThenInclude(x => x.Category)
                .Select(x => new ProductCategoryQM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    Description = x.Description,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    Products = MapProducts(x.Products)
                })
                .FirstOrDefault(x => x.Slug == slug);

            foreach (var product in category.Products)
            {

                var inv = invs.FirstOrDefault(x => x.ProductId == product.Id);
                if (inv != null)
                {
                    product.Price = inv.Price;
                    product.PriceString = inv.Price.ToMoney();
                }

                var disc = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                if (disc != null)
                {
                    product.Discount = disc.DiscountPercent;
                    var discountw = (product.Price * product.Discount) / 100;
                    product.EndDate = disc.EndDate.ToDiscountFormat();
                    product.PriceWithDiscount = (product.Price - discountw).ToMoney();
                    product.HasDiscount = product.Discount > 0;
                }
            }

            return category;
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
