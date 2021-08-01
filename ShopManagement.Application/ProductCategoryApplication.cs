using ShopManagement.Application.Constract.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using UtilityFreamwork.Application;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {

        private readonly IProductCategoryRepository productCategoryRepository;

        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            this.productCategoryRepository = productCategoryRepository;
        }



        public GenerateResult Create(CreateProductCategory category)
        {
            var result = new GenerateResult();

            if (productCategoryRepository.IsExists(x=>x.Name == category.Name))
                return result.Failed("امکان ایجاد گروه های محصولی همنام وجود ندارد");

            var chengedSlug = GenerateSlug.Slugify(category.Name);

            var newCategory = new ProductCategory(category.Name, category.Description, category.Picture,
                category.PictureTitle, category.PictureAlt, category.Keywords,
                category.MetaDescription, chengedSlug);

            productCategoryRepository.Create(newCategory);
            return result.Succedded();
        }

        public GenerateResult Edit(EditProductCategory category)
        {
            var result = new GenerateResult();
            var cat = productCategoryRepository.GetBy(category.Id);

            if (cat == null)
                return result.Failed("چنین گروه محصولی وجود ندارد");

            if (productCategoryRepository.IsExists(x=>x.Name == category.Name && x.Id != category.Id))
                return result.Failed("امکان ایجاد گروه های محصولی همنام وجود ندارد");

            var chengedSlug = category.Slug.Slugify();

            cat.Edit(category.Name, category.Description, category.Picture,
                category.PictureTitle, category.PictureAlt, category.Keywords,
                category.MetaDescription, chengedSlug);

            return result.Succedded();
        }

        public EditProductCategory GetBy(long id)
        {
            var pro = productCategoryRepository.GetBy(id);

            return new EditProductCategory
            {
                Id = pro.Id,
                Name = pro.Name,
                Picture = pro.Picture,
                PictureTitle = pro.PictureTitle,
                PictureAlt = pro.PictureAlt,
                Description = pro.Description,
                Keywords = pro.Keywords,
                MetaDescription = pro.MetaDescription,
                Slug = pro.Slug
            };
        }

        public List<ProductCategoryVM> Search(ProductCategorySearchModel searchModel)
        {
            var list = productCategoryRepository.GetAll()
                .Select(x => new ProductCategoryVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Picture = x.Picture,
                    CreationDate = x.Picture
                }).ToList();

            return list;
        }
    }
}
