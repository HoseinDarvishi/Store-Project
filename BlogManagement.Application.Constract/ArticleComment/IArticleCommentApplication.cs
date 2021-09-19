using UtilityFreamwork.Application;

namespace BlogManagement.Application.Constract.ArticleComment
{
    public interface IArticleCommentApplication
    {
        GenerateResult Add(CreateArticleComment command);

        GenerateResult Confirm(long id);
        GenerateResult Cancel (long id);
        GenerateResult Wait(long id);
    }
}
