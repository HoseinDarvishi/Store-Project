using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Application.Constract.ProductCategory
{
    public class ProductCategoryVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public string CreationDate { get; set; }
        public long ProductsCount { get; set; }
    }
}
