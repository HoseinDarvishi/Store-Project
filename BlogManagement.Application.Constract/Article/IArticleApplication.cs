using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace BlogManagement.Application.Constract.Article
{
    public interface IArticleApplication
    {
        GenerateResult Create(CreateArticle command);
        GenerateResult Edit(EditArticle command);

        GenerateResult Remove(long id);
        GenerateResult Restore(long id);

        List<ArticleVM> Search(ArticleSearchModel command);

        EditArticle GetDetails(long id);

        List<ArticleVM> GetDropDownLsit();
    }
}
