using BlogManagement.Application.Constract.Article;
using BlogManagement.Application.Constract.ArticleCategory;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UtilityFreamwork.Infra;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
   public class EditModel : PageModel
   {
      private readonly IArticleApplication _articleApplication;
      private readonly IArticleCategoryApplication _articleCategoryApplication;

      public EditModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
      {
         _articleApplication = articleApplication;
         _articleCategoryApplication = articleCategoryApplication;
      }

      public EditArticle command { get; set; }
      public SelectList categories;

      [NeedPermission(ShopPermissions.EditArticle)]
      public void OnGet(long id)
      {
         command = _articleApplication.GetDetails(id);
         categories = new SelectList(_articleCategoryApplication.GetCategoryDropDown(), "Id", "Name");
      }
      [NeedPermission(ShopPermissions.EditArticle)]
      public IActionResult OnPost(EditArticle command)
      {
         _articleApplication.Edit(command);
         return RedirectToPage("./Index");
      }
   }
}
