using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Application.Constract.Product
{
    public class ProductVM
    {
        public long Id { get; set; }

        public string Picture { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string Code { get; set; }

        public string Category { get; set; }

        public long CategoryId { get; set; }

        public string CreationDate { get; set; }
    }
}
