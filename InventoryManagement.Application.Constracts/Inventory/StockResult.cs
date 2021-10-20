
namespace InventoryManagement.Application.Constracts.Inventory
{
   public class StockResult
   {
      public bool IsInStock { get; set; }
      public string  ProductName { get; set; }
   }

   public class StockCheck
   {
      public int Count { get; set; }
      public long ProductId { get; set; }
   }
}
