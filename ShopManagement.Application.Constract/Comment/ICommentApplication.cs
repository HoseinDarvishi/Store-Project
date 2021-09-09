using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace ShopManagement.Application.Constract.Comment
{
    public interface ICommentApplication
    {
        List<CommentVM> Search(CommentSearchModel searchModel);

        GenerateResult Publish(long id);

        GenerateResult InPublish(long id);
    }
}
