using System;
using System.Collections.Generic;

namespace BlogManagement.Domain.ArticleCategoryAgg
{
    public class ArticleCategory
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Picture { get; private set; }

        public string PictureAlt { get; set; }

        public string PictureTitle { get; set; }

        public string Description { get; private set; }

        public int ShowOrder { get;private set; }

        public string MetaDescription { get; private set; }

        public string Slug { get; private set; }

        public string KeyWords { get; private set; }

        public string CanonicalAddress { get; private set; }

        public DateTime CreationDate { get; private set; }

        //public List<Article> Articles { get; private set; }

        public ArticleCategory(string name, string picture ,string pictureAlt , string pictureTitle , string description, int showOrder,
            string metaDescription, string slug, string keyWords, string canonicalAddress)
        {
            Name = name;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            ShowOrder = showOrder;
            MetaDescription = metaDescription;
            Slug = slug;
            KeyWords = keyWords;
            CanonicalAddress = canonicalAddress;
            CreationDate = DateTime.Now;
        }


        public void Edit(string name, string picture , string pictureAlt ,string pictureTitle, string description, int showOrder,
            string metaDescription, string slug, string keyWords, string canonicalAddress)
        {
            Name = name;

            if (!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            Description = description;
            ShowOrder = showOrder;
            MetaDescription = metaDescription;
            Slug = slug;
            KeyWords = keyWords;
            CanonicalAddress = canonicalAddress;
        }
    }
}
