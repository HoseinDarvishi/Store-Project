using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreQuery.Article;
using StoreQuery.ArticleCategory;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;

        public ArticleModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public List<ArticleCategoryQM> categories;
        public List<ArticleQM> latestArticles;
        public ArticleQM article;

        public void OnGet(string id)
        {
            article = _articleQuery.GetArticle(id);
            latestArticles = _articleQuery.GetLatestArticles(4);
            categories = _articleQuery.GetCategories();
        }
    }
}
