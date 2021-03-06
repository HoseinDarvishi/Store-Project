using BlogManagement.Application.Constract.ArticleCategory;
using System.Collections.Generic;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : IRepository<int , ArticleCategory>
    {
        EditArticleCategory GetDetails(int id);

        string GetSlugBy(int id);

        List<ArticleCategoryVM> Search(ArticleCategorySearchModel command);

        List<ArticleCategoryVM> GetCtegoriesDropDown();
    }
}
