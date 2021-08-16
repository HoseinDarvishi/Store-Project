using ShopManagement.Infrastructure.EFCore;
using StoreQuery.ProductCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StoreQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext context;

        public ProductCategoryQuery(ShopContext context)
        {
            this.context = context;
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
    }
}
