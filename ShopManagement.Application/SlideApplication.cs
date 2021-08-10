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

        public SlideApplication(ISlideRepository slideRepository)
        {
            this.slideRepository = slideRepository;
        }

        public GenerateResult Create(CreateSlide slide)
        {
            if (slideRepository.IsExists(x => x.Picture == slide.Picture && x.Heading == slide.Heading && x.Title == slide.Title && x.Text == slide.Text))
                return new GenerateResult().Failed("این اسلاید با مشخصات وارد شده قبلا ایجاد شده است");

            slideRepository.Create(new Slide(slide.Picture, slide.PictureAlt, slide.PictureTitle, slide.Heading,slide.Title, slide.Text, slide.BtnText , slide.Link));
            slideRepository.Save();
            return new GenerateResult().Succedded();
    
        }

        public GenerateResult Edit(EditSlide slide)
        {
            if (slideRepository.IsExists(x => x.Picture == slide.Picture && x.Heading == slide.Heading && x.Title == slide.Title && x.Text == slide.Text && x.Id != slide.Id))
                return new GenerateResult().Failed("این اسلاید با مشخصات وارد شده قبلا ایجاد شده است");

            slideRepository.Edit(slide);
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
