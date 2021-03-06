using AccountManagement.Infrastructure.EFCore;
using InventoryManagement.Application.Constracts.Inventory;
using InventoryManagement.Domain.InventoryAgg;
using ShopManagement.Infrastructure.EFCore;
using System.Collections.Generic;
using System.Linq;
using UtilityFreamwork.Application;

namespace InventoryManagement.Infrastructure.EFCore.Repositories
{
   public class InventoryRepository : Repository<long, Inventory>, IInventoryRepository
   {
      private readonly AccountContext _accountContext;
      private readonly ShopContext _shopContext;
      private readonly InventoryContext _inventoryContext;

      public InventoryRepository(InventoryContext context, ShopContext shopContext , AccountContext accountContext) : base(context)
      {
         _inventoryContext = context;
         _shopContext = shopContext;
         _accountContext = accountContext;
      }

      public void Edit(EditInventory command)
      {
         var inv = _inventoryContext.Inventories.FirstOrDefault(x => x.Id == command.Id);
         if (inv != null)
         {
            inv.Edit(command.ProductId, command.Price);
         }
      }

      public InventoryVM GetByProductId(long productId)
      {
         return _inventoryContext.Inventories.Select(x => new InventoryVM
         {
            Id = x.Id,
            Price = x.Price,
            ProductId = x.ProductId,
            InStock = x.InStock,
            Count = x.CalculateCurrentCount(),
            Product = _shopContext.Products.FirstOrDefault(x => x.Id == productId).Name,
            CreationDate = x.CreationDate.ToFarsi()
         })
         .FirstOrDefault(x => x.ProductId == productId);
      }

      public InventoryVM GetById(long id)
      {
         var pros = _shopContext.Products.Select(x => new { x.Id, x.Name });
         var inv = _inventoryContext.Inventories.Select(x => new InventoryVM
         {
            Id = x.Id,
            Price = x.Price,
            ProductId = x.ProductId,
            InStock = x.InStock,
            Count = x.CalculateCurrentCount(),
            CreationDate = x.CreationDate.ToFarsi()
         })
         .FirstOrDefault(x => x.Id == id);
         inv.Product = pros.FirstOrDefault(x => x.Id == inv.ProductId)?.Name;
         return inv;
      }

      Inventory IInventoryRepository.GetbyProductId(long productId)
      {
         return _inventoryContext.Inventories.FirstOrDefault(x => x.ProductId == productId);
      }

      public EditInventory GetDetail(long id)
      {
         return _inventoryContext.Inventories.Select(x => new EditInventory
         {
            Id = x.Id,
            Price = x.Price,
            ProductId = x.ProductId
         })
         .FirstOrDefault(x => x.Id == id);
      }

      public List<EditInventory> GetAllDetails()
      {
         return _inventoryContext.Inventories.Select(x => new EditInventory
         {
            Id = x.Id,
            Price = x.Price,
            ProductId = x.ProductId,
         })
         .ToList();
      }

      public void Increase(IncreaseInventory command)
      {
         var inv = _inventoryContext.Inventories.FirstOrDefault(x => x.Id == command.Id);
         if (inv != null)
         {
            inv.Increase(command.Count, command.OperatorId, command.Description);
         }
      }

      public void Reduce(ReduceInventory command)
      {
         var inv = _inventoryContext.Inventories.FirstOrDefault(x => x.ProductId == command.ProductId);
         if (inv != null)
         {
            inv.Reduce(command.Count, command.OperatorId, command.Description, command.OrderId);
         }
      }

      public List<InventoryVM> Search(InventorySearchModel command)
      {
         var pros = _shopContext.Products.Select(x => new { x.Id, x.Name });
         var query = _inventoryContext.Inventories.Select(x => new InventoryVM
         {
            Id = x.Id,
            Price = x.Price,
            InStock = x.InStock,
            ProductId = x.ProductId,
            Count = x.CalculateCurrentCount(),
            CreationDate = x.CreationDate.ToFarsi()
         });

         if (command.ProductId > 0)
            query = query.Where(x => x.ProductId == command.ProductId);

         if (command.InStock)
            query = query.Where(x => !x.InStock);

         var invs = query.OrderByDescending(x => x.Id).ToList();

         invs.ForEach(inv =>
             inv.Product = pros.FirstOrDefault(x => x.Id == inv.ProductId)?.Name);

         return invs;
      }

      public List<InventoryOperationVM> GetOperations(long id)
      {
         var accounts = _accountContext.Accounts.Select(x => new { x.Id, x.Fullname }).ToList();
         var inv = _inventoryContext.Inventories.FirstOrDefault(x => x.Id == id);

         var operations = inv.Operations.Select(x => new InventoryOperationVM
         {
            Id = x.Id,
            Count = x.Count,
            CurrentCount = x.CurrentCount,
            IsAdd = x.IsAdd,
            OperationDate = x.OperationDate.ToFarsi(),
            Description = x.Description,
            OperatorId = x.OperatorId,
            OrderId = x.OrderId,
         }).OrderByDescending(x => x.Id).ToList();

         foreach (var oper in operations)
         {
            oper.Operator = accounts.FirstOrDefault(x => x.Id == oper.OperatorId)?.Fullname;
         }

         return operations;
      }
   }
}
