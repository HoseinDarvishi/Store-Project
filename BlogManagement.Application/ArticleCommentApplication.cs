using BlogManagement.Application.Constract.ArticleComment;
using BlogManagement.Domain.ArticleCommentAgg;
using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace BlogManagement.Application
{
    public class ArticleCommentApplication : IArticleCommentApplication
    {
        private readonly Domain.ArticleCommentAgg.IArticleCommentRepository _articleCommentRepository;

        public ArticleCommentApplication(Domain.ArticleCommentAgg.IArticleCommentRepository articleCommentRepository)
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
            _articleCommentRepository.Save();
            return new GenerateResult().Succedded();
        }   

        public GenerateResult Confirm(long id)
        {
            var com = _articleCommentRepository.Get(id);
            if (com == null)
                return new GenerateResult().Failed("چنین نظری وجود ندارد");

            com.Confirm();
            _articleCommentRepository.Save();
            return new GenerateResult().Succedded();
        }


        public GenerateResult Wait(long id)
        {
            var com = _articleCommentRepository.Get(id);
            if (com == null)
                return new GenerateResult().Failed("چنین نظری وجود ندارد");

            com.Wait();
            _articleCommentRepository.Save();
            return new GenerateResult().Succedded();
        }

        public List<ArticleCommentVM> Search(ArticleCommentSearchModel command)
        {
            return _articleCommentRepository.Search(command);
        }
    }
}
