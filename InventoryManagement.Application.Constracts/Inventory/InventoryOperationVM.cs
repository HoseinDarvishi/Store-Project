using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Constracts.Inventory
{
    public class InventoryOperationVM
    {
        public long Id { get;  set; }

        public long Count { get;  set; }

        public long CurrentCount { get;  set; }

        public bool IsAdd { get;  set; }

        public long OperatorId { get;  set; }

        public string Operator { get; set; }

        public long OrderId { get;  set; }

        public string Description { get;  set; }

        public string OperationDate { get;  set; }
    }
}
