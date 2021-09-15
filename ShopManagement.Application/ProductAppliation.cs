using ShopManagement.Application.Constract.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityFreamwork.Application;

namespace ShopManagement.Application
{
    public class ProductAppliation : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _productCategoryRepository;

        public ProductAppliation(IProductRepository productRepository , IProductCategoryRepository productCategoryRepository , IFileUploader fileUploader)
        {
            this._productRepository = productRepository;
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }

        public GenerateResult Create(CreateProduct command)
        {
            var result = new GenerateResult();

            if (_productRepository.IsExists(x=>x.Name == command.Name))
            {
                result.Failed("امکان ثبت محصولات همنام وجود ندارد");
                return result;
            }

            var slug = command.Slug.Slugify();
            var categorySlug = _productCategoryRepository.GetSlug(command.CategoryId);
            var picturePath = _fileUploader.Uploader(command.Picture, $"{categorySlug}/{slug}");
            var pro = new Product(command.Name, command.Code, command.CategoryId, picturePath, command.PictureAlt, command.PictureTitle, command.ShortDescription, command.Description, slug, command.Keywords, command.MetaDescription);

            _productRepository.Create(pro);
            _productRepository.Save();
            return result.Succedded(); 
        }

        public GenerateResult Edit(EditProduct command)
        {
            var result = new GenerateResult();

            if (_productRepository.IsExists(x => x.Name == command.Name && x.Id != command.Id))
            {
                result.Failed("امکان ثبت محصولات همنام وجود ندارد");
                return result;
            }

            if (!_productRepository.IsExists(x=>x.Id == command.Id))
            {
                result.Failed("محصولی با چنین مشخصات یافت نشد");
                return result;
            }

            var slug = command.Slug.Slugify();
            var categorySlug = _productCategoryRepository.GetSlug(command.CategoryId);
            var picturePath = _fileUploader.Uploader(command.Picture, $"{categorySlug}/{slug}");
            var pro = _productRepository.GetProductWithCategory(command.Id);

            pro.Edit(command.Name,command.Code,command.CategoryId,picturePath,command.PictureAlt,command.PictureTitle,command.ShortDescription,command.Description,command.Keywords,command.MetaDescription,slug);

            _productRepository.Save();
            return result.Succedded();
        }

        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductVM> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public List<ProductVM> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}
