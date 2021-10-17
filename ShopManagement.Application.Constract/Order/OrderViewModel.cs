namespace ShopManagement.Application.Constract.Order
{
   public class OrderViewModel 
   {
      public long Id { get; set; }
      public long AccountId { get; set; }
      public string AccountFullName { get; set; }
      public string TotalPrice { get; set; }
      public string TotalPayment { get; set; }
      public string TotalDiscount { get; set; }
      public bool IsCanceled { get; set; }
      public bool IsPaid { get; set; }
      public string TrackingNumber { get; set; }
      public long RefId { get; set; }
      public string RegisterDate { get; set; }
   }
}
