using InventoryManagement.Application.Constracts.Inventory;

namespace StoreQuery.Inventory
{
   public interface IInventoryQuery
   {
      StockResult CheckStock(StockCheck checkItem);
   }
}
