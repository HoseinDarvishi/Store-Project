using InventoryManagement.Application.Constracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using System.Collections.Generic;

namespace InventoryManagement.Infrastructure.EFCore.Repositories
{
    public class InventoryRepository : Repository<long , Inventory>,IInventoryRepository
    {
        private readonly InventoryContext context;

        public InventoryRepository(InventoryContext context) : base (context)
        {
            this.context = context;
        }

        public void Edit(EditInventory command)
        {
            throw new System.NotImplementedException();
        }

        public InventoryVM GetBy(long id)
        {
            throw new System.NotImplementedException();
        }

        public EditInventory GetDetail(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Increase(IncreaseInventory command)
        {
            throw new System.NotImplementedException();
        }

        public void Reduce(ReduceInventory command)
        {
            throw new System.NotImplementedException();
        }

        public List<EditInventory> Search(InventorySearchModel command)
        {
            throw new System.NotImplementedException();
        }
    }
}
