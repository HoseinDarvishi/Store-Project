using InventoryManagement.Application.Constracts.Inventory;
using ShopManagement.Domain.ACL_Services;
using ShopManagement.Domain.OrderAgg;
using System.Collections.Generic;

namespace ShopManagement.Infrastructure.ShopInventoryACL
{
   public class ShopInventoryACL : IShopInventoryACL
   {
      private readonly IInventoryApplication _inventoryApp;

      public ShopInventoryACL(IInventoryApplication inventoryApp)
      {
         _inventoryApp = inventoryApp;
      }

      public bool ReduceFromInventory(List<OrderItem> items)
      {
         List<ReduceInventory> command = new();
         foreach (OrderItem item in items)
         {
            ReduceInventory reduceItem = new ReduceInventory(item.ProductId, item.Count, item.OrderId, "خرید مشتری");
            command.Add(reduceItem);
         }

         return  _inventoryApp.Reduce(command).IsSuccedded;
      }
   }
}
