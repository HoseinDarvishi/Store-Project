using ShopManagement.Application.Constract.Product;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Constract.ProductPicture
{
    public class EditProductPicture
    {
        public long Id { get; set; }

        [Required(ErrorMessage = " عکس الزامی است")]
        public string Picture { get;  set; }

        [Required(ErrorMessage = "متن جایگزین عکس الزامی است")]
        public string PictureAlt { get;  set; }

        [Required(ErrorMessage = "عنوان عکس الزامی است")]
        public string PictureTitle { get;  set; }

        [Range(1,100000000 , ErrorMessage ="محصول را انتخاب کنید")]
        public long ProductId { get;  set; }

        public List<ProductVM> Products { get; set; }
    }
}
