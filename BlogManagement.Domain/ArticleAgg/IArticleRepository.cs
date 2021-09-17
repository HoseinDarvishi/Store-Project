using BlogManagement.Application.Constract.Article;
using System.Collections.Generic;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long , Article>
    {
        List<ArticleVM> Search(ArticleSearchModel command);

        EditArticle GetDetails(long id);

        Article GetArticleWithCategory(long id);
    }
}
