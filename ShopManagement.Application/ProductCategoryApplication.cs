using ShopManagement.Application.Constract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;
using System.Linq;
using UtilityFreamwork.Application;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IArticleCategoryApplication
    {

        private readonly IProductCategoryRepository productCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository , IFileUploader fileUploader)
        {
            this.productCategoryRepository = productCategoryRepository;
            this._fileUploader = fileUploader;
        }



        public GenerateResult Create(CreateProductCategory category)
        {
            var result = new GenerateResult();

            if (productCategoryRepository.IsExists(x => x.Name == category.Name))
                return result.Failed("امکان ایجاد گروه های محصولی همنام وجود ندارد");

            var chengedSlug = GenerateSlug.Slugify(category.Name);
            var fileName = _fileUploader.Uploader(category.Picture, category.Slug);

            var newCategory = new ProductCategory(category.Name, category.Description, fileName,
                category.PictureTitle, category.PictureAlt, category.Keywords,
                category.MetaDescription, chengedSlug);

            productCategoryRepository.Create(newCategory);
            return result.Succedded();
        }

        public GenerateResult Edit(EditProductCategory category)
        {
            var result = new GenerateResult();
            var cat = productCategoryRepository.Get(category.Id);

            if (cat == null)
                return result.Failed("چنین گروه محصولی وجود ندارد");

            if (productCategoryRepository.IsExists(x => x.Name == category.Name && x.Id != category.Id))
                return result.Failed("امکان ایجاد گروه های محصولی همنام وجود ندارد");

            var chengedSlug = category.Slug.Slugify();
            var fileName = _fileUploader.Uploader(category.Picture , category.Slug);

            cat.Edit(category.Name, category.Description, fileName,
                category.PictureTitle, category.PictureAlt, category.Keywords,
                category.MetaDescription, chengedSlug);

            productCategoryRepository.Save();

            return result.Succedded();
        }

        public EditProductCategory GetBy(long id)
        {
            return productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryVM> GetSelectList()
        {
            return productCategoryRepository.Get().Select(x => new ProductCategoryVM 
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<ProductCategoryVM> Search(ProductCategorySearchModel searchModel)
        {
            return productCategoryRepository.Search(searchModel.Name)
                .Select(x => new ProductCategoryVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Picture = x.Picture,
                    CreationDate = x.CreationDate.ToString()
                }).ToList();
        }
    }
}
