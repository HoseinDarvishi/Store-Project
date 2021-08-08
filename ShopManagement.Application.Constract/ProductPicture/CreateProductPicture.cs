using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Application.Constract.ProductPicture
{
    public class CreateProductPicture
    {
        public string Picture { get; private set; }

        public string PictureAlt { get; private set; }

        public string PictureTitle { get; private set; }

        public long ProductId { get; private set; }
    }
}
