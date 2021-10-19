using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
