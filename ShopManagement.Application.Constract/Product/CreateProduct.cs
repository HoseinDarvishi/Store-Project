namespace ShopManagement.Application.Constract.Product
{
    public class CreateProduct
    {
        public string Name { get; private set; }

        public string Code { get; private set; }

        public double Price { get; private set; }

        public long CategoryId { get; private set; }

        public string Picture { get; private set; }

        public string PictureAlt { get; private set; }

        public string PictureTitle { get; private set; }

        public string ShortDescription { get; private set; }

        public string Description { get; private set; }

        public string Slug { get; set; }

        public string Keywords { get; set; }

        public string MetaDescription { get; set; }
    }
}
