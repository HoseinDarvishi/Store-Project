namespace ShopManagement.Application.Constract.ProductPicture
{
    public class EditProductPicture
    {
        public long Id { get; set; }

        public string Picture { get;  set; }

        public string PictureAlt { get;  set; }

        public string PictureTitle { get;  set; }

        public long ProductId { get;  set; }
    }
}
