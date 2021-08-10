using ShopManagement.Application.Constract.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
    public class SlideRepository : GenericRepository<long , Slide> , ISlideRepository
    {
        private readonly Context context;

        public SlideRepository(Context context) : base(context)
        {
            this.context = context;
        }

        public void Edit(EditSlide slide)
        {
            var s = context.Slides.Find(slide.Id);
            s.Edit(slide.Picture, slide.PictureAlt, slide.PictureTitle, slide.Heading, slide.Title, slide.Text, slide.BtnText);
        }

        public List<SlideVM> GetAll()
        {
            return context.Slides.Select(x => new SlideVM
            {
                Id = x.Id,
                Title = x.Title,
                Heading = x.Heading,
                Picture = x.Picture,
                Text = x.Text,
                CreationDate = x.CreationDate.ToString(),
                IsRemoved = x.IsRemoved
            })
                .ToList();
        }

        public List<EditSlide> GetAllDetail()
        {
            return context.Slides.Select(x => new EditSlide
            {
                Title = x.Title,
                Heading = x.Heading,
                Picture = x.Picture,
                Text = x.Text,
                CreationDate = x.CreationDate.ToString(),
                BtnText =x.BtnText,
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            })
            .ToList();
        }

        public EditSlide GetDetail(long id)
        {
            return context.Slides.Select(x => new EditSlide
            {
                Title = x.Title,
                Heading = x.Heading,
                Picture = x.Picture,
                Text = x.Text,
                CreationDate = x.CreationDate.ToString(),
                BtnText = x.BtnText,
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle
            })
                .FirstOrDefault(x => x.Id == id);
        }

        public void Remove(long id)
        {
            context.Slides.Find(id).Remove();
        }

        public void Restore(long id)
        {
            context.Slides.Find(id).Restore();
        }

        public SlideVM Get(long id)
        {
            return context.Slides
                .Select(x => new SlideVM
                {
                    Heading = x.Heading,
                    Text = x.Text,
                    Picture = x.Picture,
                    Title = x.Title,
                    CreationDate = x.CreationDate.ToString(),
                    IsRemoved = x.IsRemoved
                })
                .FirstOrDefault(x=>x.Id == id);
        }
    }
}
