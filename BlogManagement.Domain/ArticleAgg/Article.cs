using BlogManagement.Domain.ArticleCategoryAgg;
using BlogManagement.Domain.ArticleCommentAgg;
using System;
using System.Collections.Generic;

namespace BlogManagement.Domain.ArticleAgg
{
    public class Article
    {
        public long Id { get;private set; }

        public string Title { get; private set; }

        public string ShortDescription { get; private set; }

        public int CategoryId { get; private set; }

        public ArticleCategory Category { get; private set; }

        public string Description { get; private set; }

        public string Picture { get;private set; }

        public string PictureAlt { get; private set; }

        public string PictureTitle { get; private set; }

        public bool IsRemove { get; private set; }

        public DateTime PublishDate { get; private set; }

        public string MetaDescription { get; private set; }

        public string Slug { get; private set; }

        public string Keywords { get; private set; }

        public string CanonicalAddress { get; private set; }

        public DateTime CreationDate { get;private set; }

        public List<ArticleComment> Comments { get; private set; }


        public Article(string title, string shortDescription, int categoryId, string description,
            string picture, string pictureAlt, string pictureTitle,DateTime publishDate , string metaDescription,
            string slug, string keywords, string canonicalAddress)
        {
            Title = title;
            ShortDescription = shortDescription;
            CategoryId = categoryId;
            Description = description;
            Picture = picture;
            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;

            if (publishDate != null)
                PublishDate = publishDate;
            else
                PublishDate = DateTime.Now;

            MetaDescription = metaDescription;
            Slug = slug;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;
            IsRemove = false;
            CreationDate = DateTime.Now;
        }


        public void Edit(string title, string shortDescription, int categoryId, string description,
            string picture, string pictureAlt, string pictureTitle, DateTime publishDate, string metaDescription,
            string slug, string keywords, string canonicalAddress)
        {
            Title = title;
            ShortDescription = shortDescription;
            CategoryId = categoryId;
            Description = description;
            
            if(!string.IsNullOrWhiteSpace(picture))
                Picture = picture;

            if (publishDate != null)
                PublishDate = publishDate;

            PictureAlt = pictureAlt;
            PictureTitle = pictureTitle;
            MetaDescription = metaDescription;
            Slug = slug;
            Keywords = keywords;
            CanonicalAddress = canonicalAddress;
        }


        public void Remove()
        {
            this.IsRemove = true;
        }


        public void Restore()
        {
            this.IsRemove = false;
        }
    }
}
