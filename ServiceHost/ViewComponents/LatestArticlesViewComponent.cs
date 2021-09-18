using Microsoft.AspNetCore.Mvc;
using StoreQuery.Article;
using System.Collections.Generic;

namespace ServiceHost.ViewComponents
{
    public class LatestArticlesViewComponent : ViewComponent
    {
        private readonly IArticleQuery _articleQuery;

        public LatestArticlesViewComponent(IArticleQuery articleQuery)
        {
            _articleQuery = articleQuery;
        }

        public List<ArticleQM> Articles { get; set; }

        public IViewComponentResult Invoke()
        {
            Articles = _articleQuery.GetLatestArticles(4);
            return View("LatestArticles" , Articles);
        }
    }
}
