using BlogManagement.Infrastacture.EFCore;
using BlogManagement.Infrastacture.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using StoreQuery.Article;
using StoreQuery.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreQuery.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _blogContext;

        public ArticleQuery(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }

        public ArticleQM GetArticle(string slug)
        {
            var article = _blogContext.Articles
                .Include(x => x.Category)
                .Select(x => new ArticleQM
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    Category = x.Category.Name,
                    CategorySlug = x.Category.Slug,
                    PublishDate = x.PublishDate.ToFarsi(),
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug,
                    Description = x.Description,
                    Keywords = x.Keywords,
                    MetaDescription = x.MetaDescription,
                    CanonicalAddress = x.CanonicalAddress
                })
                .AsNoTracking()
                .FirstOrDefault(x=>x.Slug == slug);

            article.KeywordsList = article.Keywords.Split("   ").ToList();

            return article;
        }

        public List<ArticleCategoryQM> GetCategories()
        {
            return _blogContext.ArticleCategories
                .Include(x=>x.Articles)
                .Select(x => new ArticleCategoryQM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Slug = x.Slug,
                    KeyWords = x.KeyWords,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    ArticleCount = x.Articles.Where(x=>!x.IsRemove).Count(),
                }).OrderByDescending(x=>x.Id)
                .AsNoTracking()
                .ToList();
        }

        public List<ArticleQM> GetLatestArticles(int count)
        {
            return _blogContext.Articles
                .Include(x => x.Category)
                .Where(x => x.PublishDate <= DateTime.Now)
                .Where(x=>!x.IsRemove)
                .Select(x => new ArticleQM
                {
                    Id = x.Id,
                    Title = x.Title,
                    ShortDescription = x.ShortDescription,
                    Category = x.Category.Name,
                    CategorySlug = x.Category.Slug,
                    PublishDate = x.PublishDate.ToFarsi(),
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Slug = x.Slug
                })
                .AsNoTracking()
                .OrderByDescending(x => x.Id)
                .Take(count)
                .ToList();
        }

        public List<ArticleCategoryQM> GetCategoriesAsShort()
        {
            return _blogContext.ArticleCategories
                .Select(x => new ArticleCategoryQM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Slug = x.Slug,
                })
                .OrderBy(x => x.Id)
                .AsNoTracking()
                .ToList();
        }

        public ArticleCategoryQM GetCategoryWithArticlesBy(string slug)
        {
            var cat = _blogContext.ArticleCategories
                .Include(X => X.Articles)
                .Select(x => new ArticleCategoryQM
                {
                    Id = x.Id,
                    Slug = x.Slug,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    Name = x.Name,
                    PictureTitle = x.PictureTitle,
                    KeyWords = x.KeyWords,
                    Description = x.Description,
                    MetaDescription = x.MetaDescription,
                    CanonicalAddress = x.CanonicalAddress,
                    ShowOrder = x.ShowOrder,
                    ArticleCount = x.Articles.Where(x => !x.IsRemove).Count(),
                    Articles = ArticleMapping(x.Articles.Where(x=>!x.IsRemove).ToList())
                })
                .AsNoTracking()
                .FirstOrDefault(x => x.Slug == slug);

            cat.KeywordsList = cat.KeyWords.Split("   ").ToList();

            return cat;
        }

        private static List<ArticleQM> ArticleMapping(List<BlogManagement.Domain.ArticleAgg.Article> articles)
        {
            return articles.Select(x => new ArticleQM
            {
                Id = x.Id,
                Title = x.Title,
                ShortDescription = x.ShortDescription,
                Slug = x.Slug,
                Picture = x.Picture,
                PictureTitle = x.PictureTitle,
                PictureAlt = x.PictureAlt,
                PublishDate = x.PublishDate.ToFarsi(),
                MetaDescription = x.MetaDescription
            })
            .ToList();
        }
    }
}
