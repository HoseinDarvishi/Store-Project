using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace ShopManagement.Application.Constract.ProductPicture
{
    public interface IProductPictureApplication
    {
        GenerateResult Create(CreateProductPicture productPicture);

        GenerateResult Edit(EditProductPicture productPicture);

        GenerateResult Remove(long id);

        GenerateResult Restore(long id);

        EditProductPicture GetDetail(long id);

        ProductPictureVM Get(long id);

        List<ProductPictureVM> Search(ProductPictureSearchModel searchModel);

        void Save();
    }
}
