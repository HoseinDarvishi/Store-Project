using BlogManagement.Application.Constract.Article;
using BlogManagement.Application.Constract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

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

        public EditArticle command;
        public SelectList categories;

        public void OnGet(long id)
        {
            command = _articleApplication.GetDetails(id);
            categories = new SelectList(_articleCategoryApplication.GetCategoryDropDown(),"Id","Name");
        }

        public IActionResult OnPost(EditArticle article)
        {
            _articleApplication.Edit(article);
            return RedirectToPage("./Index");
        }
    }
}
