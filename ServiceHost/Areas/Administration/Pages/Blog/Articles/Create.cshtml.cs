using BlogManagement.Application.Constract.Article;
using BlogManagement.Application.Constract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class CreateModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public CreateModel(IArticleApplication articleApplication, IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = articleApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public CreateArticle command;
        public SelectList categories;

        public void OnGet()
        {
            categories = new SelectList(_articleCategoryApplication.GetCategoryDropDown(), "Id", "Name");
        }

        public IActionResult OnPost(CreateArticle command)
        {
            _articleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}
