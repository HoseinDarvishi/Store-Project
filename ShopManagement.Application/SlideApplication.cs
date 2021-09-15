using ShopManagement.Application.Constract.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityFreamwork.Application;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository slideRepository;
        private readonly IFileUploader _fileUploader;

        public SlideApplication(ISlideRepository slideRepository , IFileUploader fileUploader)
        {
            this.slideRepository = slideRepository;
            this._fileUploader = fileUploader;
        }

        public GenerateResult Create(CreateSlide slide)
        {
            var picturePath = _fileUploader.Uploader(slide.Picture, slide.Heading, "Sliders");
            slideRepository.Create(new Slide(picturePath, slide.PictureAlt, slide.PictureTitle, slide.Heading,slide.Title, slide.Text, slide.BtnText , slide.Link));
            slideRepository.Save();
            return new GenerateResult().Succedded();
    
        }

        public GenerateResult Edit(EditSlide slide)
        {
            var picturePath = _fileUploader.Uploader(slide.Picture, slide.Heading, "Sliders");
            var slid = slideRepository.GetSlide(slide.Id);
            slid.Edit(picturePath, slide.PictureAlt, slide.PictureTitle, slide.Heading, slide.Title, slide.Text, slide.BtnText, slide.Link);
            slideRepository.Save();
            return new GenerateResult().Succedded();
        }

        public SlideVM Get(long id)
        {
            return slideRepository.Get(id);
        }

        public List<SlideVM> GetAll()
        {
            return slideRepository.GetAll();
        }

        public List<EditSlide> GetAllDetails()
        {
            return slideRepository.GetAllDetail();
        }

        public EditSlide GetDetail(long id)
        {
            return slideRepository.GetDetail(id);
        }

        public GenerateResult Remove(long id)
        {
            if (!slideRepository.IsExists(x => x.Id == id))
                return new GenerateResult().Failed("چنین اسلایدی وجود ندارد");

            slideRepository.Remove(id);
            slideRepository.Save();
            return new GenerateResult().Succedded();
        }

        public GenerateResult Restore(long id)
        {
            if (!slideRepository.IsExists(x => x.Id == id))
                return new GenerateResult().Failed("چنین اسلایدی وجود ندارد");

            slideRepository.Restore(id);
            slideRepository.Save();
            return new GenerateResult().Succedded();
        }
    }
}
