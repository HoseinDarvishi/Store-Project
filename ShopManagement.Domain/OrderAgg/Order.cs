using System;
using System.Collections.Generic;

namespace ShopManagement.Domain.OrderAgg
{
   public class Order
   {
      public long Id { get; private set; }

      public long AccountId { get;private set; }

      public double TotalPrice { get; private set; }

      public double TotalPaymentPrice { get; private set; }

      public double TotalPriceWithDiscount { get; private set; }

      public bool IsPaid { get; private set; }

      public bool IsCanceled { get; private set; }

      public long RefId { get; private set; }

      public string  TrackNumber { get; private set; }

      public List<OrderItem> Items { get; private set; }

      public DateTime RegisterDate { get; private set; }

      public Order(long accountId, double totalPrice, double totalPaymentPrice, double totalPriceWithDiscount)
      {
         AccountId = accountId;
         TotalPrice = totalPrice;
         TotalPaymentPrice = totalPaymentPrice;
         TotalPriceWithDiscount = totalPriceWithDiscount;
         IsPaid = false;
         IsCanceled = false;
         RegisterDate = DateTime.Now;
         Items = new List<OrderItem>();
      }

      public void Payed(long refId)
      {
         IsPaid = true;
         if (refId > 0)
            RefId = refId;
      }

      public void SetTrackingNumber(string number)
      {
         TrackNumber = number;
      }

      public void Cancel()
      {
         IsCanceled = true;
      }

      public void AddItem(OrderItem item)
      {
         Items.Add(item);
      }
   }
}
