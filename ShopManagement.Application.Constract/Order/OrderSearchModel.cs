namespace ShopManagement.Application.Constract.Order
{
   public class OrderSearchModel
   {
      public long AccountId { get; set; }
      public bool IsCanceled { get; set; } = false;
      public bool IsPaid { get; set; }
   }
}
