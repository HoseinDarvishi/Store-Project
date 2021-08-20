using System;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class InventoryOperation 
    {
        public long Id { get;private set; }

        public long Count { get; private set; }

        public long CurrentCount { get; private set; }

        public bool IsAdd { get; private set; }

        public long OperatorId { get; private set; }

        public long OrderId { get; private set; }

        public long InventoryId { get; private set; }

        public Inventory Inventory { get;private set; }

        public string Description { get; private set; }

        public DateTime OperationDate { get; private set; }

        protected InventoryOperation()
        {

        }

        public InventoryOperation(long count, long currentCount, bool isAdd, 
            long operatorId, long orderId, long inventoryId, string description)
        {
            Count = count;
            CurrentCount = currentCount;
            IsAdd = isAdd;
            OperatorId = operatorId;
            OrderId = orderId;
            InventoryId = inventoryId;
            Description = description;
            OperationDate = DateTime.Now;
        }
    }
}
