using Microsoft.AspNetCore.Http;
using UtilityFreamwork.Application;

namespace ShopManagement.Application.Constract.Slide
{
    public class EditSlide : CreateSlide
    {
        public long Id { get; set; }
        public string CreationDate { get; set; }

        [FileExtention(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = "فرمت فابل پشتیبانی نمی شود")]
        [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "حجم فایل بیشتر از حد مجاز است")]
        public new IFormFile Picture { get; set; }

        public string PicturePath { get; set; }
    }
}
