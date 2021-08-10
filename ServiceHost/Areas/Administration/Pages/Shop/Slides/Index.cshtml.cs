using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constract.Slide;

namespace ServiceHost.Areas.Administration.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {
        private readonly ISlideApplication _slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public List<SlideVM> slides;

        public void OnGet()
        {
            slides = _slideApplication.GetAll();
        }

        public IActionResult OnGetCreate()
        {
            var slid = new CreateSlide();
            return Partial("./Create", slid);
        }

        public JsonResult OnPostCreate(CreateSlide sli)
        {
            var result = _slideApplication.Create(sli);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var sli = _slideApplication.GetDetail(id);
            return Partial("./Edit", sli);
        }

        public JsonResult OnPostEdit(EditSlide sli)
        {
            var result = _slideApplication.Edit(sli);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            _slideApplication.Remove(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            _slideApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
