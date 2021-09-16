using Microsoft.AspNetCore.Http;
using ShopManagement.Application.Constract.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UtilityFreamwork.Application;

namespace ShopManagement.Application.Constract.ProductPicture
{
    public class CreateProductPicture
    {
        [Required(ErrorMessage = " عکس الزامی است")]
        [FileExtention(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = "فرمت فابل پشتیبانی نمی شود")]
        [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "حجم فایل بیشتر از حد مجاز است")]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = "متن جایگزین عکس الزامی است")]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = "عنوان عکس الزامی است")]
        public string PictureTitle { get; set; }

        [Range(1,100000000000 , ErrorMessage = "محصول را انتخاب کنید")]
        public long ProductId { get; set; }

        public List<ProductVM> Products { get; set; }
    }
}
