using System.ComponentModel.DataAnnotations;

namespace BlogManagement.Application.Constract.ArticleComment
{
    public class CreateArticleComment
    {
        [Required(ErrorMessage = "نام الزامی است")]
        public string Name { get; set; }

        [Required(ErrorMessage = "ایمیل الزامی است")]
        public string Email { get; set; }

        public string Website { get; set; }

        [Required(ErrorMessage = "نظر خود را بنویسید")]
        public string Message { get; set; }

        [Required]
        public long ArticleId { get; set; }

        public long ParentId { get; set; }
    }
}
