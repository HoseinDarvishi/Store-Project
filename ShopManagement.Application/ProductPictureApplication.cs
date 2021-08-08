using ShopManagement.Application.Constract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityFreamwork.Application;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository pictureRepository;

        public ProductPictureApplication(IProductPictureRepository pictureRepository)
        {
            this.pictureRepository = pictureRepository;
        }

        public GenerateResult Create(CreateProductPicture productPicture)
        {
            var res = new GenerateResult();

            if (pictureRepository.IsExists(x=>x.Picture == productPicture.Picture && x.ProductId == productPicture.ProductId))
                return res.Failed("این عکس قبلا برای این محصول استفاده شده است");

            pictureRepository.Create(new ProductPicture(productPicture.Picture, productPicture.PictureAlt, productPicture.PictureTitle, productPicture.ProductId));
            pictureRepository.Save();
            return res.Succedded();
        }

        public GenerateResult Edit(EditProductPicture productPicture)
        {
            var res = new GenerateResult();

            if (pictureRepository.IsExists(x => x.Id != productPicture.Id))
                return res.Failed("چنین تصویری یافت نشد");

            if (pictureRepository.IsExists(x => x.Picture == productPicture.Picture && x.ProductId == productPicture.ProductId && x.Id != productPicture.Id))
                return res.Failed("این عکس قبلا برای این محصول استفاده شده است");

            pictureRepository.Edit(productPicture);
            pictureRepository.Save();
            return res.Succedded();
        }

        public ProductPictureVM Get(long id)
        {
            return pictureRepository.Get(id);
        }

        public EditProductPicture GetDetail(long id)
        {
            return pictureRepository.GetDetail(id);
        }

        public GenerateResult Remove(long id)
        {
            if (!pictureRepository.IsExists(x => x.Id == id))
                return new GenerateResult().Failed("چنین تصویری وجود ندارد");

            pictureRepository.Remove(id);
            pictureRepository.Save();
            return new GenerateResult().Succedded();
        }

        public GenerateResult Restore(long id)
        {
            if (!pictureRepository.IsExists(x => x.Id == id))
                return new GenerateResult().Failed("چنین تصویری وجود ندارد");

            pictureRepository.Restore(id);
            pictureRepository.Save();
            return new GenerateResult().Succedded();
        }

        public void Save()
        {
            pictureRepository.Save();
        }

        public List<ProductPictureVM> Search(ProductPictureSearchModel searchModel)
        {
            return pictureRepository.Search(searchModel);
        }
    }
}
