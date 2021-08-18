namespace InventoryManagement.Application.Constracts.Inventory
{
    public class IncreaseInventory 
    {
        public long Id { get; set; }

        public long Count { get; set; }

        public long OperatorId { get; set; }

        public string Description { get; set; }
    }

}
