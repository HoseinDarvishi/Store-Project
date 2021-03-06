using System.Collections.Generic;
using BlogManagement.Application.Constract.Article;
using BlogManagement.Application.Constract.ArticleComment;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UtilityFreamwork.Infra;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleComments
{
   public class IndexModel : PageModel
   {
      private readonly IArticleCommentApplication _commentApplication;
      private readonly IArticleApplication _articleApplication;

      private class statusComment
      {
         public int Id { get; set; }
         public string Text { get; set; }

         public statusComment(int id, string text)
         {
            Id = id;
            Text = text;
         }
      }
      private List<statusComment> statusList = new List<statusComment>
        {
            new statusComment(1 , "در انتظار"),
            new statusComment(2 , "رد شده"),
            new statusComment(3 , "تایید شده")
        };

      public IndexModel(IArticleCommentApplication commentRepository, IArticleApplication articleApplication)
      {
         _commentApplication = commentRepository;
         _articleApplication = articleApplication;
      }

      public ArticleCommentSearchModel searchModel;
      public List<ArticleCommentVM> comments;
      public SelectList articles { get; set; }
      public SelectList statuses;

      [NeedPermission(ShopPermissions.ListArticleComments)]
      public void OnGet(ArticleCommentSearchModel searchModel)
      {
         comments = _commentApplication.Search(searchModel);
         articles = new SelectList(_articleApplication.GetDropDownLsit(), "Id", "Title");
         statuses = new SelectList(statusList, "Id", "Text");
      }

      [NeedPermission(ShopPermissions.ChangeStatusArticleComments)]
      public IActionResult OnGetWait(int id)
      {
         _commentApplication.Wait(id);
         return RedirectToPage("./Index");
      }
      [NeedPermission(ShopPermissions.ChangeStatusArticleComments)]
      public IActionResult OnGetCancel(int id)
      {
         _commentApplication.Cancel(id);
         return RedirectToPage("./Index");
      }
      [NeedPermission(ShopPermissions.ChangeStatusArticleComments)]
      public IActionResult OnGetConfirm(int id)
      {
         _commentApplication.Confirm(id);
         return RedirectToPage("./Index");
      }
   }
}
