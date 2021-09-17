using BlogManagement.Application.Constract.ArticleCategory;
using BlogManagement.Domain.ArticleCategoryAgg;
using System.Collections.Generic;
using UtilityFreamwork.Application;
using GenerateResult = UtilityFreamwork.Application.GenerateResult;

namespace BlogManagement.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository , IFileUploader fileUploader)
        {
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public GenerateResult Create(CreateArticleCategory command)
        {
            if (_articleCategoryRepository.IsExists(x => x.Name == command.Name))
                return new GenerateResult().Failed("این دسته بندی قبلا ایجاد شده است");

            string picturePath = _fileUploader.Uploader(command.Picture, $"{command.Slug}", "ArticlePictures");
            var slug = command.Slug.Slugify();
            var cat = new ArticleCategory(command.Name, picturePath, command.PictureAlt , command.PictureTitle, command.Description, command.ShowOrder, command.MetaDescription
                , slug, command.KeyWords, command.CanonicalAddress);

            _articleCategoryRepository.Create(cat);
            _articleCategoryRepository.Save();

            return new GenerateResult().Succedded();
        }

        public GenerateResult Edit(EditArticleCategory command)
        {
            if (!_articleCategoryRepository.IsExists(x => x.Id == command.Id))
                return new GenerateResult().Failed("چنین دسته بندی وجود ندارد");

            if (_articleCategoryRepository.IsExists(x => x.Name == command.Name && x.Id != command.Id))
                return new GenerateResult().Failed("این دسته بندی قبلا ایجاد شده است");

            string picturePath = _fileUploader.Uploader(command.Picture, $"{command.Slug}", "ArticlePictures");
            var slug = command.Slug.Slugify();
            var cat = _articleCategoryRepository.Get(command.Id);

            cat.Edit(command.Name, picturePath , command.PictureAlt , command.PictureTitle, command.Description, command.ShowOrder, command.MetaDescription, slug, command.KeyWords, command.CanonicalAddress);

            _articleCategoryRepository.Save();

            return new GenerateResult().Succedded();
        }

        public List<ArticleCategoryVM> GetCategoryDropDown()
        {
            return _articleCategoryRepository.GetCtegoriesDropDown();
        }

        public EditArticleCategory GetDetails(int id)
        {
            return _articleCategoryRepository.GetDetails(id);
        }

        public List<ArticleCategoryVM> Search(ArticleCategorySearchModel command)
        {
            return _articleCategoryRepository.Search(command);
        }
    }
}
