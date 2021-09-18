using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Constract.Article
{
    public class EditArticle 
    {
        public long Id { get; set; }

        public string PicturePath { get; set; }

        [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "حجم عکس بیشتر از 2 مگابایت است")]
        [FileExtention(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = "فرمت فایل پشتیبانی نمیشود")]
        public IFormFile Picture { get; set; }

        public string Category { get; set; }

        [Required(ErrorMessage = "این مقذار الزامی است")]
        public string Title { get; set; }

        [Required(ErrorMessage = "این مقذار الزامی است")]
        public string ShortDescription { get; set; }

        [Required(ErrorMessage = "این مقذار الزامی است")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "این مقذار الزامی است")]
        public string Description { get; set; }

        [Required(ErrorMessage = "این مقذار الزامی است")]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = "این مقذار الزامی است")]
        public string PictureTitle { get; set; }

        public string PublishDate { get; set; }

        [Required(ErrorMessage = "این مقذار الزامی است")]
        public string MetaDescription { get; set; }

        [Required(ErrorMessage = "این مقذار الزامی است")]
        public string Slug { get; set; }

        [Required(ErrorMessage = "این مقذار الزامی است")]
        public string Keywords { get; set; }

        public string CanonicalAddress { get; set; }

    }
}
