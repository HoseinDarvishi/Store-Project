namespace ShopManagement.Application.Constract.Order
{
   public class CartItem
   {
      public long Id { get; set; }

      public string Picture { get; set; }

      public string Name { get; set; }

      public int Count { get; set; }

      public double Price { get; set; }

      public double TotalPrice => Price * Count;

      public bool IsInStock { get; set; }
   }
}
