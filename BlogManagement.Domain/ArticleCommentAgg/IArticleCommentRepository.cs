using BlogManagement.Application.Constract.ArticleComment;
using System.Collections.Generic;

namespace BlogManagement.Domain.ArticleCommentAgg
{
    public interface IArticleCommentRepository : IRepository<long , ArticleComment>
    {
        List<ArticleCommentVM> Search(ArticleCommentSearchModel command);

        ArticleCommentVM GetDetails(long id);
    }
}
