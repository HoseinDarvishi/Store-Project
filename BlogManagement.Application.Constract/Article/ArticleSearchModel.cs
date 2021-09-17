using System.Collections.Generic;
using BlogManagement.Application.Constract.ArticleCategory;

namespace BlogManagement.Application.Constract.Article
{
    public class ArticleSearchModel
    {
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public List<ArticleCategoryVM> Categories { get; set; }
    }
}
