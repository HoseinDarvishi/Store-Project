using BlogManagement.Application.Constract.Article;
using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Infrastacture.EFCore.Repositories
{
    public class ArticleRepository : Repository<long, Article>, IArticleRepository
    {
        private readonly BlogContext _blogContext;

        public ArticleRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public Article GetArticleWithCategory(long id)
        {
            return _blogContext.Articles.Include(x => x.Category).FirstOrDefault(X => X.Id == id);
        }

        public EditArticle GetDetails(long id)
        {
            return _blogContext.Articles.Include(x=>x.Category).Select(x => new EditArticle 
            {
                Id = x.Id,
                Title = x.Title,
                PicturePath = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                CategoryId = x.CategoryId,
                Category = x.Category.Name,
                Description = x.Description,
                ShortDescription = x.ShortDescription,
                Keywords = x.Keywords,
                MetaDescription = x.MetaDescription,
                Slug = x.Slug,
                CanonicalAddress = x.CanonicalAddress,
                PublishDate = x.PublishDate.ToFarsi()
            })
            .AsNoTracking()
            .FirstOrDefault(X => X.Id == id);
        }

        public List<ArticleVM> GetDropDownList()
        {
           return _blogContext.Articles.Select(x => new ArticleVM
           {
                Id = x.Id,
                Title = x.Title
           })
           .AsNoTracking()
           .ToList();
        }

        public List<ArticleVM> Search(ArticleSearchModel command)
        {
            var query = _blogContext.Articles.Include(X=>X.Category).Select(x => new ArticleVM 
            {
                Id = x.Id,
                Category = x.Category.Name,
                Picture = x.Picture,
                PublishDate = x.PublishDate.ToFarsi(),
                ShortDescription = x.ShortDescription.Substring(0,Math.Min(x.ShortDescription.Length , 50)) + " ...",
                Title = x.Title,
                CategoryId = x.CategoryId,
                IsRemoved = x.IsRemove
            })
            .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(command.Title))
                query = query.Where(x => x.Title.Contains(command.Title));

            if (command.CategoryId > 0)
                query = query.Where(x => x.CategoryId == command.CategoryId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
