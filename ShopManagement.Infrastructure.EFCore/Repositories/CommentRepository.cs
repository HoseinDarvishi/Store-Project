using ShopManagement.Application.Constract.Comment;
using ShopManagement.Domain.CommentAgg;
using System.Collections.Generic;
using System.Linq;
using UtilityFreamwork.Application;
using UtilityFreamwork.Repository;
using Microsoft.EntityFrameworkCore;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
    public class CommentRepository : Repository<long, Comment>, ICommentRepository
    {
        private readonly ShopContext _context;

        public CommentRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<CommentVM> Search(CommentSearchModel searchModel)
        {
            var query = _context.Comments
                .Include(x => x.Prodcut)
                .Select(x => new CommentVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Message = x.Message,
                    CreationDate = x.CreationDate.ToFarsi(),
                    ProductId = x.ProductId,
                    Product = x.Prodcut.Name
                }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
            {
                query = query.Where(x=>x.Name.Contains(searchModel.Name)).AsNoTracking();
            }

            if (!string.IsNullOrWhiteSpace(searchModel.Email))
            {
                query = query.Where(x => x.Email.Contains(searchModel.Email)).AsNoTracking();
            }

            var comments = query.OrderByDescending(x => x.Id).AsNoTracking().ToList();

            return comments;
        }
    }
}
