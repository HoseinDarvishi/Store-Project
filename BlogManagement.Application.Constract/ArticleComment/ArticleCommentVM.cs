using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace BlogManagement.Application.Constract.ArticleComment
{
    public class ArticleCommentVM
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string Message { get; set; }

        public long ArticleId { get; set; }

        public string Article { get; set; }

        public StatusComment Status { get; set; }

        public long ParentId { get; set; }

        public List<ArticleCommentVM> Children { get; set; }

        public string CreationDate { get; set; }

        public int ChildernCount { get; set; }
    }
}
