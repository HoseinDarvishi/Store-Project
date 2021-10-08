using System.Collections.Generic;
using BlogManagement.Application.Constract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UtilityFreamwork.Infra;

namespace ServiceHost.Areas.Administration.Pages.Blog.ArticleCategories
{
   public class IndexModel : PageModel
   {
      private readonly IArticleCategoryApplication _articleCategoryApplication;

      public IndexModel(IArticleCategoryApplication categoryApplication)
      {
         this._articleCategoryApplication = categoryApplication;
      }

      public List<ArticleCategoryVM> articleCategories;
      public ArticleCategorySearchModel searchModel;

      [NeedPermission(ShopPermissions.ListArticleCategory)]
      public void OnGet(ArticleCategorySearchModel search)
      {
         articleCategories = _articleCategoryApplication.Search(search);
      }

      [NeedPermission(ShopPermissions.CreateArticleCategory)]
      public IActionResult OnGetCreate()
      {
         return Partial("./Create", new CreateArticleCategory());
      }

      [NeedPermission(ShopPermissions.CreateArticleCategory)]
      public JsonResult OnPostCreate(CreateArticleCategory category)
      {
         var result = _articleCategoryApplication.Create(category);
         return new JsonResult(result);
      }

      [NeedPermission(ShopPermissions.EditArticleCateory)]
      public IActionResult OnGetEdit(int id)
      {
         var editCategory = _articleCategoryApplication.GetDetails(id);
         return Partial("./Edit", editCategory);
      }

      [NeedPermission(ShopPermissions.EditArticleCateory)]
      public JsonResult OnPostEdit(EditArticleCategory category)
      {
         var result = _articleCategoryApplication.Edit(category);
         return new JsonResult(result);
      }
   }
}
