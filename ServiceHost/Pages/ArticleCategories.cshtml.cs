using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreQuery.Article;
using StoreQuery.ArticleCategory;

namespace ServiceHost.Pages
{
    public class ArticleCategoriesModel : PageModel
    {
        private readonly IArticleQuery _articleQuery;

        public ArticleCategoriesModel(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public ArticleCategoryQM category;
        public List<ArticleCategoryQM> shortCategories;
        public List<ArticleQM> latestArticles;

        public void OnGet(string id)
        {
            category = _articleQuery.GetCategoryWithArticlesBy(id);
            shortCategories = _articleQuery.GetCategories();
            latestArticles = _articleQuery.GetLatestArticles(4);
        }
    }
}
