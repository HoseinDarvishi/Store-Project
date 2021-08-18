namespace InventoryManagement.Application.Constracts.Inventory
{
    public class InventoryVM
    {
        public long Id { get;  set; }

        public long ProductId { get;  set; }

        public string Product { get; set; }

        public long Count { get; set; }

        public double Price { get;  set; }

        public bool InStock { get;  set; }
    }

}
