using BlogManagement.Application.Constract.ArticleComment;
using BlogManagement.Domain.ArticleCommentAgg;
using UtilityFreamwork.Application;

namespace BlogManagement.Application
{
    public class ArticleCommentApplication : IArticleCommentApplication
    {
        private readonly IArticleCommentRepository _articleCommentRepository;

        public ArticleCommentApplication(IArticleCommentRepository articleCommentRepository)
        {
            _articleCommentRepository = articleCommentRepository;
        }

        public GenerateResult Add(CreateArticleComment command)
        {
            var com = new ArticleComment(command.Name, command.Email, command.Website, command.Message, command.ArticleId, command.ParentId);
            _articleCommentRepository.Create(com);
            _articleCommentRepository.Save();
            return new GenerateResult().Succedded();
        }

        public GenerateResult Cancel(long id)
        {
            var com = _articleCommentRepository.Get(id);
            if (com == null)
                return new GenerateResult().Failed("چنین نظری وجود ندارد");

            com.Cancel();
            return new GenerateResult().Succedded();
        }   

        public GenerateResult Confirm(long id)
        {
            var com = _articleCommentRepository.Get(id);
            if (com == null)
                return new GenerateResult().Failed("چنین نظری وجود ندارد");

            com.Confirm();
            return new GenerateResult().Succedded();
        }

        public GenerateResult Wait(long id)
        {
            var com = _articleCommentRepository.Get(id);
            if (com == null)
                return new GenerateResult().Failed("چنین نظری وجود ندارد");

            com.Wait();
            return new GenerateResult().Succedded();
        }
    }
}
