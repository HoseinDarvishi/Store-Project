using Microsoft.AspNetCore.Http;

namespace BlogManagement.Application.Constract.Article
{
    public class EditArticle : CreateArticle
    {
        public long Id { get; set; }

        public string PicturePath { get; set; }

        [MaxFileSize(2 * 1024 * 1024, ErrorMessage = "حجم عکس بیشتر از 2 مگابایت است")]
        [FileExtention(new string[] { ".jpg", ".jpeg", ".png" }, ErrorMessage = "فرمت فایل پشتیبانی نمیشود")]
        public new IFormFile Picture { get; set; }

        public string Category { get; set; }

    }


}
