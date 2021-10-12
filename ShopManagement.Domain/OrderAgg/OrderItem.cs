using System;

namespace ShopManagement.Domain.OrderAgg
{
   public class OrderItem
   {
      public long Id { get;private set; }

      public long  ProductId { get; private set; }

      public int Count { get; private set; }

      public double Price { get; private set; }

      public int DiscountRate { get; private set; }

      public long OrderId { get; private set; }

      public Order Order { get; private set; }

      public DateTime RegisterDate { get; private set; }


      public OrderItem(long productId, int count, double price, int discountRate)
      {
         ProductId = productId;
         Count = count;
         Price = price;
         DiscountRate = discountRate;
      }
   }
}
