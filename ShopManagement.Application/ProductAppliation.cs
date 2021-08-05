using ShopManagement.Application.Constract.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityFreamwork.Application;

namespace ShopManagement.Application
{
    public class ProductAppliation : IProductApplication
    {
        private readonly IProductRepository productRepository;

        public ProductAppliation(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public GenerateResult Create(CreateProduct command)
        {
            var result = new GenerateResult();

            if (productRepository.IsExists(x=>x.Name == command.Name))
            {
                result.Failed("امکان ثبت محصولات همنام وجود ندارد");
                return result;
            }

            var slug = command.Slug.Slugify();

            var pro = new Product(command.Name, command.Code, command.Price, command.CategoryId, command.Picture, command.PictureAlt, command.PictureTitle, command.ShortDescription, command.Description, slug, command.Keywords, command.MetaDescription);

            productRepository.Create(pro);
            productRepository.Save();
            return result.Succedded(); 
        }

        public GenerateResult Edit(EditProduct command)
        {
            var result = new GenerateResult();

            if (productRepository.IsExists(x => x.Name == command.Name && x.Id != command.Id))
            {
                result.Failed("امکان ثبت محصولات همنام وجود ندارد");
                return result;
            }

            if (productRepository.IsExists(x=>x.Id != command.Id))
            {
                result.Failed("محصولی با چنین مشخصات یافت نشد");
                return result;
            }

            var slug = command.Slug.Slugify();
            var pro = productRepository.GetProductWithCategory(command.Id);

            pro.Edit(command.Name,command.Code,command.Price,command.CategoryId,command.Picture,command.PictureAlt,command.PictureTitle,command.ShortDescription,command.Description,command.Keywords,command.MetaDescription,slug);

            productRepository.Save();
            return result.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
            return productRepository.GetDetails(id);
        }

        public List<ProductVM> GetProducts()
        {
            return productRepository.GetProducts();
        }

        public List<ProductVM> Search(ProductSearchModel searchModel)
        {
            return productRepository.Search(searchModel);
        }
    }
}
