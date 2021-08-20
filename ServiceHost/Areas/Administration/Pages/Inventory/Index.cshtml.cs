using System.Collections.Generic;
using InventoryManagement.Application.Constracts.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Constract.Product;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        private readonly IProductApplication _productApplication;
        private readonly IInventoryApplication _inventoryApplication;

        public IndexModel(IProductApplication productApplication, IInventoryApplication inventoryApplication)
        {
            _productApplication = productApplication;
            _inventoryApplication = inventoryApplication;
        }

        public List<InventoryVM> Inventories;
        public InventorySearchModel inventorySearchModel { get; set; }
        public SelectList Products { get; set; }

        public void OnGet(InventorySearchModel search)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            Inventories = _inventoryApplication.Search(search);
        }

        public IActionResult OnGetCreate()
        {
            var createDiscount = new CreateInventory()
            {
                Products = _productApplication.GetProducts()
            };
            return Partial("./Create", createDiscount);
        }

        public JsonResult OnPostCreate(CreateInventory inv)
        {
            var result = _inventoryApplication.Create(inv);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var editInv = _inventoryApplication.GetDetail(id);
            editInv.Products = _productApplication.GetProducts();
            return Partial("./Edit", editInv);
        }

        public JsonResult OnPostEdit(EditInventory editInventory)
        {
            var result = _inventoryApplication.Edit(editInventory);
            return new JsonResult(result);
        }

        public IActionResult OnGetIncrease(long id) 
        {
            var increase = new IncreaseInventory
            {
                Id = id
            };
            return Partial("./Increase", increase);
        }

        public JsonResult OnPostIncrease(IncreaseInventory increase)
        {
            var res = _inventoryApplication.Increase(increase);
            return new JsonResult(res);
        }

        public IActionResult OnGetReduce(long id)
        {
            var reduce = new ReduceInventory
            {
                Id = id
            };
            return Partial("./Reduce", reduce);
        }

        public JsonResult OnPostReduce(ReduceInventory reduce)
        {
            var res = _inventoryApplication.Reduce(reduce);
            return new JsonResult(res);
        }

        public IActionResult OnGetLog(long id)
        {
            var operations = _inventoryApplication.GetOperations(id);
            return Partial("Operations", operations);
        }
    }
}
