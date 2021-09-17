using BlogManagement.Application.Constract.Article;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogManagement.Domain.ArticleAgg
{
    public interface IArticleRepository : IRepository<long , Article>
    {
        List<ArticleVM> Search(ArticleSearchModel command);

        EditArticle GetDetails(long id);
        

    }
}
