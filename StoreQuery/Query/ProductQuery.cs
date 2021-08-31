using DiscountManagement.Infrastructure;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;
using StoreQuery.Product;
using System.Collections.Generic;
using System.Linq;
using UtilityFreamwork.Application;

namespace StoreQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext context;
        private readonly InventoryContext invContext;
        private readonly DiscountContext disContext;

        public ProductQuery(InventoryContext invContext, ShopContext context, DiscountContext discountContext)
        {
            this.invContext = invContext;
            this.context = context;
            this.disContext = discountContext;
        }

        public List<ProductQM> GetLatestProducts()
        {
            var invs = invContext.Inventories.Select(x => new { x.ProductId, x.Price }).ToList();
            var discounts = disContext.CustomerDiscounts.Where(x => x.IsActive).Select(x => new { x.ProductId, x.DiscountPercent }).ToList();

            var products = context.Products
                .Include(x => x.Category)
                .Select(x => new ProductQM 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Category = x.Category.Name,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ShortDescription = x.ShortDescription,
                    Slug = x.Slug
                })
                .OrderByDescending(x=>x.Id)
                .ToList();

            foreach (var product in products)
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

            return products;
        }
    }
}
