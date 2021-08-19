using System;
using System.Collections.Generic;
using System.Linq;

namespace InventoryManagement.Domain.InventoryAgg
{
    public class Inventory
    {
        public long Id { get; private set; }

        public long ProductId { get; private set; }

        public double Price { get;private set; }

        public bool InStock { get;private set; }

        public List<InventoryOperation> Operations { get;private set; }

        public DateTime CreationDate { get;private set; }


        public Inventory(long productId, double price)
        {
            ProductId = productId;
            Price = price;
            InStock = false;
            CreationDate = DateTime.Now;
        }

        public void Edit(long productId, double price)
        {
            ProductId = productId;
            Price = price;
        }

        public long CalculateCurrentCount()
        {
            var sum = Operations.Where(x => x.IsAdd).Sum(x=>x.Count);
            var mines = Operations.Where(x => !x.IsAdd).Sum(x => x.Count);
            return sum - mines;
        }


        public void Increase(long count ,long operatorId , string description)
        {
            var currentCount = CalculateCurrentCount() + count;
            var operation = new InventoryOperation(count , currentCount , true ,operatorId , 0 , Id , description);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }

        public void Reduce(long count , long operatorId , string description , long orderId)
        {
            var currentCount = CalculateCurrentCount() - count;
            var operation = new InventoryOperation(count, currentCount, false, operatorId, orderId, Id, description);
            Operations.Add(operation);
            InStock = currentCount > 0;
        }
    }
}
