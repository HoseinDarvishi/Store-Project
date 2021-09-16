using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Constract.ArticleCategory
{
    public class CreateArticleCategory
    {
        [Required(ErrorMessage = "این مورد الزامی است")]
        public string Name { get; set; }

        [Required(ErrorMessage = "این مورد الزامی است")]
        [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "حجم فایل نباید بیشتر از 2 مگابایت باشد")]
        [FileExtention(new string[] {".jpeg",".jpg",".png" } , ErrorMessage = "فرمت فایل پشتیبانی نمیشود")]
        public IFormFile Picture { get;  set; }

        [Required(ErrorMessage = "این مورد الزامی است")]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = "این مورد الزامی است")]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = "این مورد الزامی است")]
        public string Description { get;  set; }

        [Required(ErrorMessage = "این مورد الزامی است")]
        public int ShowOrder { get;  set; }

        [Required(ErrorMessage = "این مورد الزامی است")]
        public string MetaDescription { get;  set; }

        [Required(ErrorMessage = "این مورد الزامی است")]
        public string Slug { get;  set; }

        [Required(ErrorMessage = "این مورد الزامی است")]
        public string KeyWords { get;  set; }

        public string CanonicalAddress { get;  set; }
    }

}
