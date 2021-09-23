using System.Collections.Generic;
using BlogManagement.Application.Constract.ArticleComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreQuery.Article;
using StoreQuery.ArticleCategory;

namespace ServiceHost.Pages
{
   public class ArticleModel : PageModel
   {
      private readonly IArticleQuery _articleQuery;
      private readonly IArticleCommentApplication _commentApplication;

      public ArticleModel(IArticleQuery articleQuery, IArticleCommentApplication commentApplication)
      {
         _articleQuery = articleQuery;
         _commentApplication = commentApplication;
      }

      public List<ArticleCategoryQM> categories;
      public List<ArticleQM> latestArticles;
      public ArticleQM article;
      public CreateArticleComment comment;

      public void OnGet(string id)
      {
         article = _articleQuery.GetArticle(id);
         latestArticles = _articleQuery.GetLatestArticles(4);
         categories = _articleQuery.GetCategories();
      }

      public IActionResult OnPost(CreateArticleComment comment)
      {
         _commentApplication.Add(comment);
         return RedirectToPage("/Article" , comment.ArticleSlug);
      }
   }
}
