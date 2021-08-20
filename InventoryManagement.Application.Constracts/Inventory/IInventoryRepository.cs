using System.Collections.Generic;

namespace InventoryManagement.Application.Constracts.Inventory
{
    public interface IInventoryRepository : IRepository<long , Domain.InventoryAgg.Inventory>
    {
        void Edit(EditInventory command);

        void Increase(IncreaseInventory command);

        void Reduce(ReduceInventory command);

        EditInventory GetDetail(long id);
        List<EditInventory> GetAllDetails();

        InventoryVM GetByProductId(long productId);
        InventoryVM GetById(long id);

        InventoryManagement.Domain.InventoryAgg.Inventory GetbyProductId(long productId);

        List<InventoryVM> Search(InventorySearchModel command);

        List<InventoryOperationVM> GetOperations(long id);
    }
}
