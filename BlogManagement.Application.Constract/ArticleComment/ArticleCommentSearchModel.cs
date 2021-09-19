using UtilityFreamwork.Application;

namespace BlogManagement.Application.Constract.ArticleComment
{
    public class ArticleCommentSearchModel
    {
        public string Name { get; set; }

        public long ArticleId { get; set; }

        public StatusComment Status { get; set; }
    }
}
