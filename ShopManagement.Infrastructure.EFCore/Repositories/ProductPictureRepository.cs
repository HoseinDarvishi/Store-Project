using ShopManagement.Application.Constract.ProductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using UtilityFreamwork.Application;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
    public class ProductPictureRepository : GenericRepository<long , ProductPicture> , IProductPictureRepository
    {
        private readonly ShopContext context;

        public ProductPictureRepository(ShopContext context) : base(context)
        {
            this.context = context;
        }

        public void Edit(EditProductPicture productPicture)
        {

        }

        public EditProductPicture GetDetail(long id)
        {
            return context.ProductPictures.Select(x=> new EditProductPicture 
            {
                Id = x.Id,
                PicturePath = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            })
            .FirstOrDefault(x=>x.Id == id);
        }

        public void Remove(long id)
        {
            var pro = Get(id);
            pro.Remove();
        }

        public void Restore(long id)
        {
            var pro = Get(id);
            pro.Restore();
        }

        ProductPictureVM IProductPictureRepository.Get(long id)
        {
            return context.ProductPictures.Include(x=>x.Product).Select(x => new ProductPictureVM
            {
                Id = x.Id,
                Picture = x.Picture,
                CreationDate =x.CreationDate.ToFarsi(),
                Product = x.Product.Name
            })
            .FirstOrDefault(x => x.Id == id);
        }

       public List<ProductPictureVM> Search(ProductPictureSearchModel searchModel)
        {
            var query = context.ProductPictures.Include(x => x.Product).Select(x => new ProductPictureVM
            {
                Id = x.Id,
                CreationDate = x.CreationDate.ToFarsi(),
                Picture = x.Picture,
                ProductId = x.ProductId,
                Product = x.Product.Name,
                IsRemoved = x.IsRemoved
            });

            if (searchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            return query.OrderBy(x => x.Id).ToList();
       }

        public ProductPicture GetPictureWithProductAndCategory(long id)
        {
            return context.ProductPictures.Include(x => x.Product).ThenInclude(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public ProductPicture GetPicture(long id)
        {
            return context.ProductPictures.FirstOrDefault(x => x.Id == id);
        }
    }
}
