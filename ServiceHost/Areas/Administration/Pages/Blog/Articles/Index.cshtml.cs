using System.Collections.Generic;
using BlogManagement.Application.Constract.Article;
using BlogManagement.Application.Constract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class IndexModel : PageModel
    {
        private readonly IArticleApplication _articleApplication;
        private readonly IArticleCategoryApplication _articleCategoryApplication;

        public IndexModel(IArticleApplication categoryApplication , IArticleCategoryApplication articleCategoryApplication)
        {
            _articleApplication = categoryApplication;
            _articleCategoryApplication = articleCategoryApplication;
        }

        public List<ArticleVM> articles;
        public ArticleSearchModel searchModel;
        public SelectList categories;

        public void OnGet(ArticleSearchModel search)
        {
            categories = new SelectList(_articleCategoryApplication.GetCategoryDropDown(),"Id" , "Name");
            articles = _articleApplication.Search(search);
        }

        public IActionResult OnGetRemove(long id)
        {
            _articleApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            _articleApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
