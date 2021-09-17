using BlogManagement.Application.Constract.Article;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace BlogManagement.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IArticleCategoryRepository _articleCategoryRepository;

        public ArticleApplication(IArticleRepository articleRepository ,IArticleCategoryRepository articleCategoryRepository , IFileUploader fileUploader)
        {
            _articleRepository = articleRepository;
            _articleCategoryRepository = articleCategoryRepository;
            _fileUploader = fileUploader;
        }

        public GenerateResult Create(CreateArticle command)
        {
            if (_articleRepository.IsExists(x => x.Title == command.Title))
                return new GenerateResult().Failed("مقاله ای با این عنوان قبلا ایجاد شده است");

            var slug = command.Slug.Slugify();
            string catSlug = _articleCategoryRepository.GetSlugBy(command.CategoryId);
            var path = $"{catSlug}/{slug}";
            var picturePath = _fileUploader.Uploader(command.Picture, path, "ArticlePictures");
            var publishDate = command.PublishDate.ToGeorgianDateTime();

            var newArt = new Article(command.Title , command.ShortDescription , command.CategoryId ,
                command.Description , picturePath , command.PictureAlt , command.PictureTitle,
                publishDate , command.MetaDescription , slug , command.Keywords , command.CanonicalAddress);

            _articleRepository.Create(newArt);
            _articleRepository.Save();
            return new GenerateResult().Succedded();
        }

        public GenerateResult Edit(EditArticle command)
        {

            if (_articleRepository.IsExists(x => x.Title == command.Title && x.Id != command.Id))
                return new GenerateResult().Failed("مقاله ای با این عنوان قبلا ایجاد شده است");

            var art = _articleRepository.GetArticleWithCategory(command.Id);
                
            if (art == null)
                return new GenerateResult().Failed("چنین مقاله ای وجود ندارد");
            

            var slug = command.Slug.Slugify();
            var path = $"{art.Category.Slug}/{slug}";
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            var picturePath = _fileUploader.Uploader(command.Picture, path, "ArticlePictures");

            art.Edit(command.Title , command.ShortDescription , command.CategoryId 
                ,command.Description , picturePath , command.PictureAlt , command.PictureTitle 
                , publishDate, command.MetaDescription , slug , command.Keywords , command.CanonicalAddress);
           
            _articleRepository.Save();
            return new GenerateResult().Succedded();
        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);
        }

        public GenerateResult Remove(long id)
        {
            if (!_articleRepository.IsExists(x => x.Id == id))
                return new GenerateResult().Failed("چنین مقاله ای یافت نشد");

            _articleRepository.Get(id).Remove();
            _articleRepository.Save();
            return new GenerateResult().Succedded();
        }

        public GenerateResult Restore(long id)
        {
            if (!_articleRepository.IsExists(x => x.Id == id))
                return new GenerateResult().Failed("چنین مقاله ای یافت نشد");

            _articleRepository.Get(id).Restore();
            _articleRepository.Save();
            return new GenerateResult().Succedded();
        }

        public List<ArticleVM> Search(ArticleSearchModel command)
        {
            return _articleRepository.Search(command);
        }
    }
}