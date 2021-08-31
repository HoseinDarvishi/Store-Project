using System;
using System.Collections.Generic;
using System.Text;

namespace StoreQuery.Product
{
    public interface IProductQuery
    {
        List<ProductQM> GetLatestProducts();
    }
}
