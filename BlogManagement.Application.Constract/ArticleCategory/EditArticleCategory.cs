using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Constract.ArticleCategory
{
    public class EditArticleCategory : CreateArticleCategory 
    {
        public int Id { get; set; }

        public string PicturePath { get; set; }

        [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "حجم فایل نباید بیشتر از 2 مگابایت باشد")]
        [FileExtention(new string[] { ".jpeg", ".jpg", ".png" }, ErrorMessage = "فرمت فایل پشتیبانی نمیشود")]
        public new IFormFile Picture { get; set; }
    }

}
