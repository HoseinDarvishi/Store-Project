using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Constract.Order;

namespace ServiceHost.Pages
{
   public class CartModel : PageModel
   {
      public List<CartItem> CartItems { get; set; }

      public void OnGet()
      {
         var serilizer = new JavaScriptSerializer();
         var value = Request.Cookies["cart"];
         CartItems = serilizer.Deserialize<List<CartItem>>(value);
      }

      public IActionResult OnGetRemove(long id)
      {
         var value = Request.Cookies["cart"];

         // Delete Old Cookie
         Response.Cookies.Delete("cart");

         // Deserilize Coockie
         var serilizer = new JavaScriptSerializer();
         var cartItems = serilizer.Deserialize<List<CartItem>>(value);

         // Removing Selected Product
         var itemForDel = cartItems.FirstOrDefault(x => x.Id == id);
         cartItems.Remove(itemForDel);

         // Setting Option For Cookie
         var option = new CookieOptions { Expires = DateTime.Now.AddDays(5), Path = "/" };

         // Add Cookie
         Response.Cookies.Append("cart", serilizer.Serialize(cartItems), option);

         return RedirectToPage("/Cart");
      }
   }
}
