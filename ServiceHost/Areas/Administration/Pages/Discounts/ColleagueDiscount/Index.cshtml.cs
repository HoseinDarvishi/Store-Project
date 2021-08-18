using System.Collections.Generic;
using DiscountManagement.Application.Constracts.ColleagueDiscount;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Constract.Product;

namespace ServiceHost.Areas.Administration.Pages.Discounts.ColleagueDiscount
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication productApplication;
        private readonly IColleagueDiscountApplication colleagueApplication;

        public IndexModel(IProductApplication productApplication, IColleagueDiscountApplication colleagueApplication)
        {
            this.productApplication = productApplication;
            this.colleagueApplication = colleagueApplication;
        }

        public List<ColleagueDiscountVM> Discounts;
        public ColleagueDiscountSearchModel searchModel { get; set; }
        public SelectList Products { get; set; }

        public void OnGet(ColleagueDiscountSearchModel search)
        {
            Products = new SelectList(productApplication.GetProducts() , "Id" , "Name");
            Discounts = colleagueApplication.Search(search);
        }

        public IActionResult OnGetCreate()
        {
            var createDiscount = new CreateColleagueDiscount()
            {
                Products = productApplication.GetProducts()
            };
            return Partial("./Create", createDiscount);
        }

        public JsonResult OnPostCreate(CreateColleagueDiscount discount)
        {
            var result = colleagueApplication.Create(discount);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var editDiscount = colleagueApplication.GetDetail(id);
            editDiscount.Products = productApplication.GetProducts();
            return Partial("./Edit", editDiscount);
        }

        public JsonResult OnPostEdit(EditColleagueDiscount editDiscount)
        {
            var result = colleagueApplication.Edit(editDiscount);
            return new JsonResult(result);
        }

        public IActionResult OnGetDeActive(long id)
        {
            colleagueApplication.DeActive(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetActive(long id)
        {
            colleagueApplication.Active(id);
            return RedirectToPage("./Index");
        }
    }
}
