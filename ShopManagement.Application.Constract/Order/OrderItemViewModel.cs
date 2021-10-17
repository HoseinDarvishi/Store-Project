namespace ShopManagement.Application.Constract.Order
{
   public class OrderItemViewModel
   {
      public long ProductId { get; set; }
      public string ProductName { get; set; }
      public int Count { get; set; }
      public double UnitPrice { get; set; }
      public int DiscountRate { get; set; }
      public double TotalPrice { get; set; }
      public double TotalDiscount { get; set; }
      public double TotalPayment { get; set; }
      public long OrderId { get; set; }
   }
}
