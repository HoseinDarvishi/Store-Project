using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace BlogManagement.Application.Constract.ArticleComment
{
    public interface IArticleCommentApplication
    {
        GenerateResult Add(CreateArticleComment command);

        List<ArticleCommentVM> Search(ArticleCommentSearchModel command);

        GenerateResult Confirm(long id);
        GenerateResult Cancel (long id);
        GenerateResult Wait(long id);
    }
}
