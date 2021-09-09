using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace ShopManagement.Application.Constract.Comment
{
    public interface ICommentApplication
    {
        GenerateResult Add(CreateComment comment);
    
        GenerateResult Publish(long id);

        GenerateResult InPublish(long id);

        List<CommentVM> Search(CommentSearchModel searchModel);
    }
}
