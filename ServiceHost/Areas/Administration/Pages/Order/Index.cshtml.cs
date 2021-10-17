using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Constract.Order;
using UtilityFreamwork.Infra;

namespace ServiceHost.Areas.Administration.Pages.Order
{
   public class IndexModel : PageModel
   {
      private readonly IOrderApplication orderApplication;

      public IndexModel(IOrderApplication orderApplication)
      {
         this.orderApplication = orderApplication;
      }

      public OrderSearchModel searchModel { get; set; }
      public List<OrderViewModel> Orders { get; set; }

      [NeedPermission(ShopPermissions.ListOrders)]
      public void OnGet(OrderSearchModel searchModel)
      {
         Orders = orderApplication.Search(searchModel);
      }

      public IActionResult OnGetCancel(long id)
      {
         orderApplication.Cancel(id);
         return RedirectToPage("./Index");
      }

      public IActionResult OnGetRestore(long id)
      {
         orderApplication.Restore(id);
         return RedirectToPage("./Index");
      }

      public IActionResult OnGetFactor(long id)
      {
         var items = orderApplication.GetItemsBy(id);
         return Partial("OrderItems", items);
      }
   }
}
