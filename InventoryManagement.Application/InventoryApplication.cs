using InventoryManagement.Application.Constracts;
using InventoryManagement.Application.Constracts.Inventory;
using System;
using System.Collections.Generic;

namespace InventoryManagement.Application
{
    public class InventoryApplication : IInventoryApplication
    {
        public GenerateResult Create(CreateInventory command)
        {
            throw new NotImplementedException();
        }

        public GenerateResult Edit(EditInventory command)
        {
            throw new NotImplementedException();
        }

        public List<EditInventory> GetAllDetails()
        {
            throw new NotImplementedException();
        }

        public InventoryVM GetBy(long id)
        {
            throw new NotImplementedException();
        }

        public EditInventory GetDetail(long id)
        {
            throw new NotImplementedException();
        }

        public GenerateResult Increase(IncreaseInventory command)
        {
            throw new NotImplementedException();
        }

        public GenerateResult Reduce(List<ReduceInventory> command)
        {
            throw new NotImplementedException();
        }

        public GenerateResult Reduce(ReduceInventory command)
        {
            throw new NotImplementedException();
        }

        public List<InventoryVM> Search(InventorySearchModel command)
        {
            throw new NotImplementedException();
        }
    }
}
