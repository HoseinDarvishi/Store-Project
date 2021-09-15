using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using UtilityFreamwork.Application;

namespace ShopManagement.Application.Constract.Slide
{
    public class CreateSlide
    {
        [Required(ErrorMessage = "مسیر عکس الزامی است")]
        [FileExtention(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = "فرمت فابل پشتیبانی نمی شود")]
        [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "حجم فایل بیشتر از حد مجاز است")]
        public IFormFile Picture { get; set; }

        [Required(ErrorMessage = "متن جایگزین عکس الزامی است")]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = "عنوان عکس الزامی است")]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = "سر تیتر اسلاید الزامی است")]
        public string Heading { get; set; }

        public string Title { get; set; }

        [Required(ErrorMessage = "متن اسلاید الزامی است")]
        public string Text { get; set; }

        [Required(ErrorMessage = "متن دکمه الزامی است")]
        public string BtnText { get; set; }

        [Required(ErrorMessage = "لینک الزامی است")]
        public string Link { get; set; }
    }
}
