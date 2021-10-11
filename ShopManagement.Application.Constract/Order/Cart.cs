using System.Collections.Generic;

namespace ShopManagement.Application.Constract.Order
{
   public class Cart
   {
      public List<CartItem> Items { get; set; }

      public double TotalPrice { get; set; }

      public double TotalWithDiscount { get; set; }

      public double TotalPayment { get; set; }

      public Cart() 
      {
         Items = new List<CartItem>();
      }

      public Cart(double totalPrice, double totalDiscount, double totalPayment)
      {
         Items = new List<CartItem>();
         TotalPrice = totalPrice;
         TotalWithDiscount = totalDiscount;
         TotalPayment = totalPayment;
      }

      public void Add(CartItem item)
      {
         Items.Add(item);
         TotalPrice += item.TotalPrice;
         TotalWithDiscount += item.PriceWithDiscount;
         TotalPayment += item.TotalPaymentPrice;
      }

      ////
      ////   This Work Currently But It is not Safe !!
      ////
      //public static Cart CalculateCart(List<CartItem> items)
      //{
      //   double totalPrice = 0;
      //   double totalPayment = 0;
      //
      //   foreach (var item in items)
      //   {
      //      totalPrice += item.TotalPrice;
      //      totalPayment += item.TotalPaymentPrice;
      //   }
      //
      //   double totalDiscount = totalPrice - totalPayment;
      //
      //   return new Cart(totalPrice, totalDiscount, totalPayment);
      //}
   }
}
