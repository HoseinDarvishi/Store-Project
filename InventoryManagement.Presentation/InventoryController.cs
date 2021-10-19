using InventoryManagement.Application.Constracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using StoreQuery.Inventory;
using System.Collections.Generic;

namespace InventoryManagement.Presentation
{
   [ApiController]
   [Route("api/[Controller]")]
   public class InventoryController : ControllerBase
   {
      private readonly IInventoryApplication _inventoryApplication;
      private readonly IInventoryQuery _inventoryQuery;

      public InventoryController(IInventoryApplication inventoryApplication , IInventoryQuery inventoryQuery)
      {
         _inventoryApplication = inventoryApplication;
         _inventoryQuery = inventoryQuery;
      }

      [HttpGet("{id}")]
      public List<InventoryOperationVM> GetOperationsBy(long id)
      {
         return _inventoryApplication.GetOperations(id);
      }

      [HttpPost]
      public StockResult CheckStock([FromBody]StockCheck checkItem)
      {
         return _inventoryQuery.CheckStock(checkItem);
      }
   }
}
