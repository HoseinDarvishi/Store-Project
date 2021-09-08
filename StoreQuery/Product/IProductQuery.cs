﻿using System.Collections.Generic;

namespace StoreQuery.Product
{
    public interface IProductQuery
    {
        List<ProductQM> GetLatestProducts();

        List<ProductQM> Search(string value);

        ProductQM GetProduct(string slug);
    }
}
