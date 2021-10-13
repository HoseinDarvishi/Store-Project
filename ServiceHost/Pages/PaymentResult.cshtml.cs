using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
   public class PaymentResultModel : PageModel
   {
      public IActionResult OnGet()
      {
         if (TempData["mess"]  == null)
         {
            return RedirectToPage("/NotFound");
         }
         return Page();
      }

      public IActionResult OnGetSuccess(string mess , string secur)
      {
         if ((!string.IsNullOrWhiteSpace(mess)) && (secur == "8m00t90qw1e"))
         {
            TempData["mess"] = mess;
            return RedirectToPage("/PaymentResult");
         }

         return RedirectToPage("/NotFound");
      }

      public IActionResult OnGetFail(string secur)
      {
         if (secur == "faw93df337sw")
         {
            TempData["mess"] = "1";
            return RedirectToPage("/PaymentResult");
         }
         return RedirectToPage("/NotFound");
      }
   }
}
