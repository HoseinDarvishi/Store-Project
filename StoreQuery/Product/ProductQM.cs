using System.Collections.Generic;

namespace StoreQuery.Product
{
    public class ProductQM
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Picture { get; set; }

        public List<ProductPictureQM> pictures { get; set; }

        public string PictureAlt { get; set; }

        public string PictureTitle { get; set; }

        public double Price { get; set; }

        public string PriceString { get; set; }

        public int Discount { get; set; }

        public string EndDate { get; set; }

        public string PriceWithDiscount { get; set; }

        public string Slug { get; set; }

        public string Description { get; set; }

        public string Keywords { get; set; }

        public string ShortDescription { get; set; }

        public string Category { get; set; }

        public string CategorySlug { get; set; }

        public bool HasDiscount { get; set; }
    }

    public class ProductPictureQM
    {
        public string Picture { get; set; }

        public string PictureAlt { get;set; }

        public string PictureTitle { get; set; }

        public long ProductId { get; set; }

        public bool IsRemoved { get; set; }
    }
}