using ShopManagement.Application.Constract.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _pictureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;

        public ProductPictureApplication(IProductPictureRepository pictureRepository, IProductRepository productRepository, IFileUploader fileUploader)
        {
            _pictureRepository = pictureRepository;
            _productRepository = productRepository;
            _fileUploader = fileUploader;
        }



        public GenerateResult Create(CreateProductPicture productPicture)
        {
            var res = new GenerateResult();
            var product = _productRepository.GetProductWithCategory(productPicture.ProductId);
            var PicturePath = _fileUploader.Uploader(productPicture.Picture, $"{product.Category.Slug}/{product.Slug}");

            _pictureRepository.Create(new ProductPicture(PicturePath, productPicture.PictureAlt, productPicture.PictureTitle, productPicture.ProductId));
            _pictureRepository.Save();
            return res.Succedded();
        }

        public GenerateResult Edit(EditProductPicture productPicture)
        {
            var res = new GenerateResult();

            if (!_pictureRepository.IsExists(x => x.Id == productPicture.Id))
                return res.Failed("چنین تصویری یافت نشد");

            var pic = _pictureRepository.GetPicture(productPicture.Id);

            var picture = _pictureRepository.GetPictureWithProductAndCategory(productPicture.Id);
            var PicturePath = _fileUploader.Uploader(productPicture.Picture, $"{picture.Product.Category.Slug}/{picture.Product.Slug}");

            pic.Edit(PicturePath, productPicture.PictureAlt, productPicture.PictureTitle, productPicture.ProductId);
            
            _pictureRepository.Save();
            return res.Succedded();
        }

        public ProductPictureVM Get(long id)
        {
            return _pictureRepository.Get(id);
        }

        public EditProductPicture GetDetail(long id)
        {
            return _pictureRepository.GetDetail(id);
        }

        public GenerateResult Remove(long id)
        {
            if (!_pictureRepository.IsExists(x => x.Id == id))
                return new GenerateResult().Failed("چنین تصویری وجود ندارد");

            _pictureRepository.Remove(id);
            _pictureRepository.Save();
            return new GenerateResult().Succedded();
        }

        public GenerateResult Restore(long id)
        {
            if (!_pictureRepository.IsExists(x => x.Id == id))
                return new GenerateResult().Failed("چنین تصویری وجود ندارد");

            _pictureRepository.Restore(id);
            _pictureRepository.Save();
            return new GenerateResult().Succedded();
        }

        public void Save()
        {
            _pictureRepository.Save();
        }

        public List<ProductPictureVM> Search(ProductPictureSearchModel searchModel)
        {
            return _pictureRepository.Search(searchModel);
        }
    }
}
