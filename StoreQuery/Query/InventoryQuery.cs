using InventoryManagement.Application.Constracts.Inventory;
using InventoryManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Infrastructure.EFCore;
using StoreQuery.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreQuery.Query
{
   public class InventoryQuery : IInventoryQuery
   {
      private readonly ShopContext _shopContext;
      private readonly InventoryContext _inventoryContext;

      public InventoryQuery(InventoryContext inventoryContext, ShopContext shopContext)
      {
         _inventoryContext = inventoryContext;
         _shopContext = shopContext;
      }

      public StockResult CheckStock(StockCheck checkItem)
      {
         var inv = _inventoryContext.Inventories.Select(x => new { x.ProductId, x.InStock, Count = x.CalculateCurrentCount()})
            .AsNoTracking().FirstOrDefault(x => x.ProductId == checkItem.ProductId);

         if (inv == null || inv.Count < checkItem.Count)
         {
            return new StockResult
            {
               IsInStock = false,
               ProductName = _shopContext.Products.FirstOrDefault(X => X.Id == checkItem.ProductId)?.Name
            };
         }

         return new StockResult{ IsInStock = true };
      }
   }
}
