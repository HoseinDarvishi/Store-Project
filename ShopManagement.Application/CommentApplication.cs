using ShopManagement.Application.Constract.Comment;
using ShopManagement.Domain.CommentAgg;
using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace ShopManagement.Application
{
    public class CommentApplication : ICommentApplication
    {
        private readonly ICommentRepository commentRepository;

        public CommentApplication(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }

        public GenerateResult Add(CreateComment comment)
        {
            commentRepository.Create(new Comment(comment.Name, comment.Email, comment.Message, comment.ProductId));
            commentRepository.Save();
            return new GenerateResult().Succedded();
        }

        public GenerateResult InPublish(long id)
        {
            var comment = commentRepository.Get(id);

            if (comment == null)
            {
                return new GenerateResult().Failed("چنین نظری وجود ندارد");
            }

            comment.Cancel();
            commentRepository.Save();
            return new GenerateResult().Succedded();
        }

        public GenerateResult Publish(long id)
        {
            var comment = commentRepository.Get(id);

            if (comment == null)
            {
                return new GenerateResult().Failed("چنین نظری وجود ندارد");
            }

            comment.Publish();
            commentRepository.Save();
            return new GenerateResult().Succedded();
        }

        public List<CommentVM> Search(CommentSearchModel searchModel)
        {
            return commentRepository.Search(searchModel);
        }
    }
}
