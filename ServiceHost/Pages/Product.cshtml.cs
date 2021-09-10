using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constract.Comment;
using StoreQuery.Product;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        private readonly IProductQuery productQuery;
        private readonly ICommentApplication commentApplication;
        public ProductQM Product { get; set; }
        public CreateComment Comment {get;set;}

        public ProductModel(IProductQuery productQuery , ICommentApplication CommentApplication)
        {
            this.productQuery = productQuery;
            commentApplication = CommentApplication;
        }

        public void OnGet(string id)
        {
            Product = productQuery.GetProduct(id);
        }

        public IActionResult OnPostAddComment(CreateComment createComment)
        {
            commentApplication.Add(createComment);
            return RedirectToPage("./Product", new {id = createComment.ProductSlug });
        }
    }
}
