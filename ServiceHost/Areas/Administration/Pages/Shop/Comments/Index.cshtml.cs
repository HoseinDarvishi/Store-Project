using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Constract.Comment;
using UtilityFreamwork.Infra;

namespace ServiceHost.Areas.Administration.Pages.Shop.Comments
{
   public class IndexModel : PageModel
   {
      public class Statuses
      {
         public string Text { get; set; }
         public int Code { get; set; }

         public Statuses(string text, int code)
         {
            Text = text;
            Code = code;
         }
      }
      private List<Statuses> statuses = new List<Statuses>()
        {
            new Statuses("در انتظار" , 1),
            new Statuses("رد شده" , 2),
            new Statuses("تایید شدخ" , 3),
        };

      private readonly ICommentApplication commentApplication;

      public IndexModel(ICommentApplication commentApplication)
      {
         this.commentApplication = commentApplication;
      }

      public List<CommentVM> Comments { get; set; }
      public CommentSearchModel SearchModel { get; set; }
      public SelectList StatusesComment;

      
      [NeedPermission(ShopPermissions.ListProductComments)]
      public void OnGet(CommentSearchModel commentSearch)
      {
         Comments = commentApplication.Search(commentSearch);
         StatusesComment = new SelectList(statuses, "Code", "Text");
      }

      [NeedPermission(ShopPermissions.ChangeStatusProductComments)]
      public IActionResult OnGetInPublish(long id)
      {
         commentApplication.InPublish(id);
         return RedirectToPage("./Index");
      }

      [NeedPermission(ShopPermissions.ChangeStatusProductComments)]
      public IActionResult OnGetPublish(long id)
      {
         commentApplication.Publish(id);
         return RedirectToPage("./Index");
      }
   }
}
