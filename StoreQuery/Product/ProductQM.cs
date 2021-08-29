
namespace StoreQuery.Product
{
    public class ProductQM
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public string PictureAlt { get; set; }

        public string PictureTitle { get; set; }

        public double Price { get; set; }

        public string PriceString { get; set; }

        public int Discount { get; set; }

        public string PriceWithDiscount { get; set; }

        public string Slug { get; set; }

        public string ShortDescription { get; set; }

        public string Category { get; set; }

        public bool HasDiscount { get; set; }
    }
}
