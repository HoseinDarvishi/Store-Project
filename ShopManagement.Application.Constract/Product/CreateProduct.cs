﻿using ShopManagement.Application.Constract.ProductCategory;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Constract.Product
{
    public class CreateProduct
    {

        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string Name { get;  set; }

        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string Code { get;  set; }

        [Range(200, 1000000000000000, ErrorMessage = "این مقدار الزامی است")]
        public double Price { get;  set; }

        [Range(1,10000000 , ErrorMessage = "این مقدار الزامی است")]
        public long CategoryId { get;  set; }

        public string Picture { get;  set; }

        public string PictureAlt { get;  set; }

        public string PictureTitle { get;  set; }

        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string ShortDescription { get;  set; }

        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string Description { get;  set; }

        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string Keywords { get; set; }

        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string MetaDescription { get; set; }

        public List<ProductCategoryVM> categories { get; set; }
    }
}