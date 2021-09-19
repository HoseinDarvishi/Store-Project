using StoreQuery.ArticleCategory;
using System.Collections.Generic;

namespace StoreQuery.Article
{
    public interface IArticleQuery
    {
        List<ArticleQM> GetLatestArticles(int count);

        List<ArticleQM> GetArticelsByCategory(int id);
        List<ArticleQM> GetArticelsByCategory(string slug);

        ArticleQM GetArticle(string slug);

        List<ArticleCategoryQM> GetCategories();
        List<ArticleCategoryQM> GetCategoriesAsShort();
    }
}
