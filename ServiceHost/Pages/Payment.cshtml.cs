using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Constract.Order;
using StoreQuery.Query;

namespace ServiceHost.Pages
{
   public class PaymentModel : PageModel
   {
      private readonly IComputCart _computCart;

      public PaymentModel(IComputCart computCart)
      {
         _computCart = computCart;
      }

      public Cart cart;

      public void OnGet()
      {
         var serilizer = new JavaScriptSerializer();
         var value = Request.Cookies["cart"];
         var cartItems = serilizer.Deserialize<List<CartItem>>(value);

         if (cartItems != null)
            cart = _computCart.CalcCart(cartItems);
      }
   }
}
