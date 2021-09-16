using BlogManagement.Application.Constract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Infrastacture.EFCore.Repositories
{
    public class ArticleCategoryRepository : Repository<int, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _blogContext;

        public ArticleCategoryRepository(BlogContext blogContext) : base(blogContext)
        {
            _blogContext = blogContext;
        }

        public EditArticleCategory GetDetails(int id)
        {
            return _blogContext.ArticleCategories.Select(x => new EditArticleCategory
            {
                Id = x.Id,
                Name = x.Name,
                PicturePath = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShowOrder = x.ShowOrder,
                Slug = x.Slug,
                Description=x.Description,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                CanonicalAddress = x.CanonicalAddress
            })
             .AsNoTracking().FirstOrDefault(x=>x.Id == id);
        }

        public List<ArticleCategoryVM> Search(ArticleCategorySearchModel command)
        {
            var query = _blogContext.ArticleCategories.Select(x => new ArticleCategoryVM
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShowOrder = x.ShowOrder,
                CreationDate = x.CreationDate.ToFarsi()
            }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(command.Name))
            {
                query = query.Where(x => x.Name.Contains(command.Name));
            }

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
