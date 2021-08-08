using ShopManagement.Domain.ProductAgg;
using System;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public class ProductPicture
    {
        public long Id { get; private set; }

        public string Picture { get; private set; }

        public string PictureAlt { get; private set; }

        public string PictureTitle { get; private set; }

        public long ProductId { get;private set; }

        public Product Product { get; private set; }

        public DateTime CreationDate { get; private set; }

        public bool IsRemoved { get; private set; }


        public ProductPicture(string picture, string pictureAlt, string pictureTitle, long productId)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ProductId = productId;
            IsRemoved = false;
        }


        public void Edit(string picture, string pictureAlt, string pictureTitle, long productId)
        {
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            ProductId = productId;
        }


        public void Remove()
        {
            IsRemoved = true;
        }

        public void Restore()
        {
            IsRemoved = false;
        }
    }
}
