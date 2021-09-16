
namespace BlogManagement.Application.Constract.ArticleCategory
{
    public class ArticleCategoryVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string PictureAlt { get; set; }

        public string PictureTitle { get; set; }

        public string Description { get; set; }

        public int ShowOrder { get; set; }

        public string CreationDate { get; set; }

        public long ArticleCount { get; set; }
    }
}
