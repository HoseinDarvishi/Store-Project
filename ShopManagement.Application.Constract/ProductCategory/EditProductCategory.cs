using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using UtilityFreamwork.Application;

namespace ShopManagement.Application.Constract.ProductCategory
{
    public class EditProductCategory
    {
        public long Id { get; set; }


        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = " این مقدار الزامی است")]
        [FileExtention(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = "فرمت فابل پشتیبانی نمی شود")]
        [MaxFileSizeAttribute(2 * 1024 * 1024, ErrorMessage = "حجم فایل بیشتر از حد مجاز است")]
        public IFormFile Picture { get; set; }

        public string PictureTitle { get; set; }

        public string PictureAlt { get; set; }


        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string Keywords { get; set; }


        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string MetaDescription { get; set; }


        [Required(ErrorMessage = "این مقدار الزامی است")]
        public string Slug { get; set; }
    }
}
