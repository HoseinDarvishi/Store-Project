using Microsoft.AspNetCore.Mvc;
using ShopManagement.Domain.ProductAgg;
using StoreQuery.Product;
using System.Collections.Generic;

namespace ServiceHost.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class ProductsController : ControllerBase
   {
      private readonly IProductQuery _productQuery;
      private readonly IProductRepository _productRepository;

      public ProductsController(IProductQuery productQuery, IProductRepository productRepository)
      {
         _productQuery = productQuery;
         _productRepository = productRepository; 
      }

      [HttpGet]
      public List<ProductQM> GetLatestProducts()
      {
         return _productQuery.GetLatestProducts();
      }


      [HttpGet("{id}")]
      public Product GetProduct(long id)
      {
         return _productRepository.Get(id);
      }
   }
}
