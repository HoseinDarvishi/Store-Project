using ShopManagement.Application.Constract.Comment;
using System.Collections.Generic;
using UtilityFreamwork.Repository;

namespace ShopManagement.Domain.CommentAgg
{
    public interface ICommentRepository : IRepository<long , Comment>
    {
        List<CommentVM> Search(CommentSearchModel searchModel);
    }
}
