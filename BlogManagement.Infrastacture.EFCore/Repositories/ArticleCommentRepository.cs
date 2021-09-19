using BlogManagement.Application.Constract.ArticleComment;
using BlogManagement.Domain.ArticleCommentAgg;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BlogManagement.Infrastacture.EFCore.Repositories
{
    public class ArticleCommentRepository : Repository<long, ArticleComment>, IArticleCommentRepository
    {
        private readonly BlogContext _context;

        public ArticleCommentRepository(BlogContext context) : base(context)
        {
            _context = context;
        }

        public ArticleCommentVM GetDetails(long id)
        {
            return _context.ArticleComments.Include(x=>x.Article)
                .Select(x => new ArticleCommentVM 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message,
                    Status = x.Status,
                    ArticleId = x.ArticleId,
                    CreationDate = x.CreationDate.ToFarsi(),
                    Website = x.Website,
                    ParentId = x.ParentId,
                    Children = ArticleMap(x.Children),
                    ChildernCount = x.Children.Count(),
                    Article = x.Article.Title
                })
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleCommentVM> Search(ArticleCommentSearchModel command)
        {
            var query = _context.ArticleComments
                .Include(x => x.Article)
                .Select(x => new ArticleCommentVM 
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message,
                    Status = x.Status,
                    ArticleId = x.ArticleId,
                    CreationDate = x.CreationDate.ToFarsi(),
                    Website = x.Website,
                    ParentId = x.ParentId,
                    Children = ArticleMap(x.Children),
                    ChildernCount = x.Children.Count(),
                    Article = x.Article.Title
                })
                .AsNoTracking();

            if (!string.IsNullOrWhiteSpace(command.Name))
                query = query.Where(x => x.Name.Contains(command.Name)).Where(x=>x.Message.Contains(command.Name));

            if (command.Status > 0)
                query = query.Where(X => X.Status == command.Status);

            if (command.ArticleId > 0)
                query = query.Where(x => x.ArticleId == command.ArticleId);


            return query.OrderByDescending(x => x.Id).ToList();
        }

        private static List<ArticleCommentVM> ArticleMap(List<ArticleComment> children)
        {
            return children.Select(x => new ArticleCommentVM
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Message = x.Message,
                Status = x.Status,
                CreationDate = x.CreationDate.ToFarsi(),
            }).ToList();
        }
    }
}
