using ShopManagement.Application.Constract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {

        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }



        public void Create(CreateProductCategory category)
        {
            
        }

        public void Edit(EditProductCategory category)
        {
            throw new NotImplementedException();
        }

        public ProductCategory GetBy(long id)
        {
            throw new NotImplementedException();
        }

        public List<ProductCategoryVM> Search(ProductCategorySearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}
