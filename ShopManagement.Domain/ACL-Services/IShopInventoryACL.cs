using ShopManagement.Domain.OrderAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.ACL_Services
{
   public interface IShopInventoryACL
   {
      bool ReduceFromInventory(List<OrderItem> items);
   }
}
