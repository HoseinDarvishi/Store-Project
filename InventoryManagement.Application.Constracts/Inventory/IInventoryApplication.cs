using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace InventoryManagement.Application.Constracts.Inventory
{
   public interface IInventoryApplication
   {
      GenerateResult Create(CreateInventory command);
      GenerateResult Edit(EditInventory command);
      GenerateResult Increase(IncreaseInventory command);
      GenerateResult Reduce(List<ReduceInventory> command);
      GenerateResult Reduce(ReduceInventory command);

      EditInventory GetDetail(long id);
      List<EditInventory> GetAllDetails();

      List<InventoryVM> Search(InventorySearchModel command);
      InventoryVM GetBy(long productId);

      List<InventoryOperationVM> GetOperations(long id);
   }
}
