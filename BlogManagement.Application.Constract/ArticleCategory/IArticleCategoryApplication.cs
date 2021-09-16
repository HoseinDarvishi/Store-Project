using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace BlogManagement.Application.Constract.ArticleCategory
{
    public interface IArticleCategoryApplication
    {
        GenerateResult Create(CreateArticleCategory command);

        GenerateResult Edit(EditArticleCategory command);

        List<ArticleCategoryVM> Search(ArticleCategorySearchModel command);

        EditArticleCategory GetDetails(int id);
    }
}
