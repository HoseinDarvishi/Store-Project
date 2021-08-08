using ShopManagement.Application.Constract.ProductPicture;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IProductPictureRepository : IGenericRepository<long, ProductPicture>
    {
        void Edit(EditProductPicture productPicture);

        ProductPictureVM Get(long id);

        EditProductPicture GetDetail(long id);

        List<ProductPictureVM> Search(ProductPictureSearchModel searchModel);

        void Remove(long id);
        void Restore(long id);
    }
}
