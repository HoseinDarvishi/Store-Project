namespace InventoryManagement.Application.Constracts.Inventory
{
   public class ReduceInventory
   {
      public long Id { get; set; }

      public long ProductId { get; set; }

      public long Count { get; set; }

      public long OperatorId { get; set; }

      public long OrderId { get; set; }

      public string Description { get; set; }

      public ReduceInventory()
      {

      }

      public ReduceInventory(long productId, long count, long orderId, string description)
      {
         ProductId = productId;
         Count = count;
         OrderId = orderId;
         Description = description;
      }
   }

}
