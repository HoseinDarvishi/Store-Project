using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product
    {
        public long Id { get;private set; }

        public string Name { get; private set; }

        public string Code { get; private set; }

        public double Price { get; private set; }

        public long CategoryId { get; private set; }

        public bool IsInStock { get; private set; }

        public string Picture { get; private set; }

        public string PictureAlt { get; private set; }

        public string PictureTitle { get; private set; }

        public string ShortDescription { get; private set; }

        public string Description { get; private set; }

        public string Slug { get; set; }

        public string Keywords { get; set; }

        public string MetaDescription { get; set; }

        public DateTime CreationDate { get; private set; }

        public ProductCategory Category { get; private set; }

        public List<ProductPicture> Pictures { get; private set; }


        public Product(string name, string code, double price, long categoryId,
            string picture, string pictureAlt, string pictureTitle,
            string shortDescription, string description , string slug , string keywords , string metaDescription )
        {
            Name = name;
            Code = code;
            Price = price;
            CategoryId = categoryId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Description = description;
            Slug = slug;
            Keywords = keywords;
            MetaDescription = metaDescription;
            IsInStock = true;
            CreationDate = DateTime.Now;
        }


        public void Edit(string name, string code, double price, long categoryId,
                         string picture, string pictureAlt, string pictureTitle,
                         string shortDescription, string description, string keywords, string metaDescription , string slug)
        {
            Name = name;
            Code = code;
            Price = price;
            CategoryId = categoryId;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ShortDescription = shortDescription;
            Description = description;
            Keywords = keywords;
            MetaDescription = metaDescription;
            Slug = slug;
        }

        public void InStock()
        {
            IsInStock = true;
        }

        public void NoStock()
        {
            IsInStock = false;
        }
    }
}
