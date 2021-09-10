using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ShopManagement.Application.Consract.ProductCategory
{
    public class CreateProductCategory
    {

        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Picture { get;  set; }

        public string PictureTitle { get; set; }

        public string PictureAlt { get; set; }


        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string Keywords { get;  set; }


        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string MetaDescription { get; set; }


        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string Slug { get; set; }
    }
}
