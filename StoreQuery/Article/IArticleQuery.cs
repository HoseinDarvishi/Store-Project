using StoreQuery.ArticleCategory;
using System.Collections.Generic;

namespace StoreQuery.Article
{
    public interface IArticleQuery
    {
        List<ArticleQM> GetLatestArticles(int count);

        ArticleCategoryQM GetCategoryWithArticlesBy(string slug);

        ArticleQM GetArticle(string slug);

        List<ArticleCategoryQM> GetCategories();
        List<ArticleCategoryQM> GetCategoriesAsShort();
    }
}
