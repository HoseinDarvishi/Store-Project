using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Constract.Order;
using StoreQuery.Product;

namespace ServiceHost.Pages
{
   public class CartModel : PageModel
   {
      private readonly IProductQuery _productQuery;

      public CartModel(IProductQuery productQuery)
      {
         _productQuery = productQuery;
      }

      public List<CartItem> CartItems;

      public void OnGet()
      {
         var serilizer = new JavaScriptSerializer();
         var val = Request.Cookies["cart"];
         var cartitems = serilizer.Deserialize<List<CartItem>>(val);

         if (cartitems.Count != 0 && cartitems != null)
            CartItems = _productQuery.CheckInventoryStatus(cartitems);
      }

      public IActionResult OnGetRemove(long id)
      {
         var serializer = new JavaScriptSerializer();

         // Get Cookie
         var value = Request.Cookies["cart"];

         // Remove Selected Item
         var cartItems = serializer.Deserialize<List<CartItem>>(value);
         var itemToRemove = cartItems.FirstOrDefault(x => x.Id == id);
         cartItems.Remove(itemToRemove);

         // Setting Cookie Options
         var options = new CookieOptions 
         { 
            Expires = DateTime.Now.AddDays(2),
            Path="/",
            HttpOnly=false,
            IsEssential=true,
            SameSite = SameSiteMode.None,
            Secure = true
         };

         // Delete Old Cookie
         Response.Cookies.Delete("cart");

         // Append New Cookie
         Response.Cookies.Append("cart", serializer.Serialize(cartItems), options);

         return RedirectToPage("/Cart");
      }

      public RedirectToPageResult OnGetPayment()
      {
         var serilizer = new JavaScriptSerializer();
         var val = Request.Cookies["cart"];
         var cartitems = serilizer.Deserialize<List<CartItem>>(val);

         if (cartitems.Count != 0 && cartitems != null)
            CartItems = _productQuery.CheckInventoryStatus(cartitems);
         else
            return RedirectToPage("/Cart");

         return CartItems.Any(x => !x.IsInStock) ? RedirectToPage("/Cart") : RedirectToPage("/Payment");
      }
   }
}
