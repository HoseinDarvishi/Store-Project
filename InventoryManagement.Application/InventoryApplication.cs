using InventoryManagement.Application.Constracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace InventoryManagement.Application
{
   public class InventoryApplication : IInventoryApplication
   {
      private readonly IInventoryRepository _inventoryRepository;
      private readonly IAuthHelper _authHelper;

      public InventoryApplication(IInventoryRepository inventoryRepository , IAuthHelper authHelper)
      {
         _inventoryRepository = inventoryRepository;
         _authHelper = authHelper;
      }

      public GenerateResult Create(CreateInventory command)
      {
         if (_inventoryRepository.IsExists(x => x.ProductId == command.ProductId))
            return new GenerateResult().Failed("انبار این محصول قبلا ایجاد شده است");

         var inv = new Inventory(command.ProductId, command.Price);
         _inventoryRepository.Create(inv);
         _inventoryRepository.Save();
         return new GenerateResult().Succedded();
      }

      public GenerateResult Edit(EditInventory command)
      {
         if (!_inventoryRepository.IsExists(x => x.Id == command.Id))
            return new GenerateResult().Failed("چنین انبار محصولی وجود ندارد");
         if (_inventoryRepository.IsExists(x => x.ProductId == command.ProductId && x.Id != command.Id))
            return new GenerateResult().Failed("انبار این محصول قبلا ایجاد شده است");

         _inventoryRepository.Edit(command);
         _inventoryRepository.Save();
         return new GenerateResult().Succedded();
      }

      public List<EditInventory> GetAllDetails()
      {
         return _inventoryRepository.GetAllDetails();
      }

      public InventoryVM GetBy(long productId)
      {
         return _inventoryRepository.GetByProductId(productId);
      }

      public EditInventory GetDetail(long id)
      {
         return _inventoryRepository.GetDetail(id);
      }

      public GenerateResult Increase(IncreaseInventory command)
      {
         var inv = _inventoryRepository.Get(command.Id);
         if (inv == null)
            return new GenerateResult().Failed("چنین انبار محصولی وجود ندارد");

         const long operId = 1;
         inv.Increase(command.Count, operId, command.Description);
         _inventoryRepository.Save();
         return new GenerateResult().Succedded();
      }

      public GenerateResult Reduce(List<ReduceInventory> command)
      {
         foreach (var item in command)
         {
            var inv = _inventoryRepository.GetbyProductId(item.ProductId);
            if (inv == null)
               return new GenerateResult().Failed("چنین انبار محصولی وجود ندارد");

            var operId = _authHelper.CurrentAccountId();
            inv.Reduce(item.Count, operId, item.Description, item.OrderId);
         }

         _inventoryRepository.Save();
         return new GenerateResult().Succedded();
      }

      public GenerateResult Reduce(ReduceInventory command)
      {
         var inv = _inventoryRepository.Get(command.Id);
         if (inv == null)
            return new GenerateResult().Failed("چنین انبار محصولی وجود ندارد");

         var operId = _authHelper.CurrentAccountId();
         inv.Reduce(command.Count, operId, command.Description, 0);
         _inventoryRepository.Save();
         return new GenerateResult().Succedded();
      }

      public List<InventoryVM> Search(InventorySearchModel command)
      {
         return _inventoryRepository.Search(command);
      }

      public List<InventoryOperationVM> GetOperations(long id)
      {
         return _inventoryRepository.GetOperations(id);
      }
   }
}
