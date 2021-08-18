using System.Collections.Generic;
using  inventory = InventoryManagement.Domain.InventoryAgg.Inventory;

namespace InventoryManagement.Application.Constracts.Inventory
{
    public interface IInventoryRepository : IRepository<long , inventory>
    {
        void Edit(EditInventory command);

        void Increase(IncreaseInventory command);

        void Reduce(ReduceInventory command);

        EditInventory GetDetail(long id);

        InventoryVM GetBy(long id);

        List<EditInventory> Search(InventorySearchModel command);
    }
}
