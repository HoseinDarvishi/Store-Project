using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Nancy.Json;
using ShopManagement.Application.Constract.Order;
using StoreQuery.Product;
using StoreQuery.Query;
using UtilityFreamwork.Application;
using UtilityFreamwork.Application.ZarinPal;

namespace ServiceHost.Pages
{
   [Authorize]
   public class PaymentModel : PageModel
   {
      private readonly IAuthHelper _authHelper;
      private readonly IComputCart _computCart;
      private readonly ICartHolder _cartHolder;
      private readonly IProductQuery _productQuery;
      private readonly IZarinPalFactory _zarinFactory;
      private readonly IOrderApplication _orderApplication;

      public PaymentModel(IComputCart computCart , ICartHolder cartHolder , IProductQuery productQuery 
         ,IOrderApplication orderApplication , IZarinPalFactory zarinFactory , IAuthHelper authHelper)
      {
         _computCart = computCart;
         _cartHolder = cartHolder;
         _productQuery = productQuery;
         _orderApplication = orderApplication;
         _zarinFactory = zarinFactory;
         _authHelper = authHelper;
      }

      public Cart Cart;

      public void OnGet()
      {
         var serilizer = new JavaScriptSerializer();
         var value = Request.Cookies["cart"];
         var cartItems = serilizer.Deserialize<List<CartItem>>(value);

         if (cartItems != null)
         {
            Cart = _computCart.CalcCart(cartItems);
            _cartHolder.Set(Cart);
         }
      }

      public IActionResult OnGetPay()
      {
         var cart = _cartHolder.Get();
         var result = _productQuery.CheckInventoryStatus(cart.Items);

         if (result.Any(x=>!x.IsInStock))
            return RedirectToPage("/Cart");

         var orderId = _orderApplication.PlaceOrder(cart);
         string description = $"خرید کالا";

         var responsePay = _zarinFactory.CreatePaymentRequest(cart.TotalPayment.ToString(), "" , "user@gmail.com", description, orderId);

         return Redirect($"https://{_zarinFactory.Prefix}.zarinpal.com/pg/StartPay{responsePay.Authority}");
      }

      public IActionResult OnGetCheckPayment([FromQuery] string authority ,[FromQuery] string status ,[FromQuery] long orderId)
      {
         var orderPrice = _orderApplication.GetTotalPaymentPriceById(orderId);

         var verifyResult = _zarinFactory.CreateVerificationRequest(authority, orderPrice.ToString());

         if (status == "OK" && verifyResult.Status >= 100)
         {
            var trackingNo = _orderApplication.Pay(orderId, verifyResult.RefID);
            Response.Cookies.Delete("cart");
            return RedirectToPage("PaymentResult", "Success" ,new { mess = trackingNo , secur = "8m00t90qw1e"} );
         }
         else
            return RedirectToPage("PaymentResult", "Fail" , new {secur = "faw93df337sw"});
      }
   }
}
