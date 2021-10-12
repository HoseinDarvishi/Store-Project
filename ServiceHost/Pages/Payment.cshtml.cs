using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Constract.Order;
using StoreQuery.Product;
using StoreQuery.Query;

namespace ServiceHost.Pages
{
   public class PaymentModel : PageModel
   {
      private readonly IComputCart _computCart;
      private readonly ICartHolder _cartHolder;
      private readonly IProductQuery _productQuery;

      public PaymentModel(IComputCart computCart , ICartHolder cartHolder , IProductQuery productQuery)
      {
         _computCart = computCart;
         _cartHolder = cartHolder;
         _productQuery = productQuery;
      }

      public Cart cart;

      public void OnGet()
      {
         var serilizer = new JavaScriptSerializer();
         var value = Request.Cookies["cart"];
         var cartItems = serilizer.Deserialize<List<CartItem>>(value);

         if (cartItems != null)
         {
            cart = _computCart.CalcCart(cartItems);
            _cartHolder.Set(cart);
         }
      }

      public IActionResult OnGetPay()
      {
         var cart2 = _cartHolder.Get();
         var result = _productQuery.CheckInventoryStatus(cart2.Items);

         if (result.Any(x=>!x.IsInStock))
            return RedirectToPage("/Cart");

         return RedirectToPage("/Payment");
      }
   }
}
