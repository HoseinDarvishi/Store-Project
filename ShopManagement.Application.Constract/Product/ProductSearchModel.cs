using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Application.Constract.Product
{
    public class ProductSearchModel
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public long CategoryId { get; set; }
    }
}
