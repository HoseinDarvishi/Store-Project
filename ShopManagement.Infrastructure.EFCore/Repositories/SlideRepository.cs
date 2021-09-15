using ShopManagement.Application.Constract.Slide;
using ShopManagement.Domain.SlideAgg;
using System.Collections.Generic;
using System.Linq;
using UtilityFreamwork.Application;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
    public class SlideRepository : GenericRepository<long , Slide> , ISlideRepository
    {
        private readonly ShopContext context;

        public SlideRepository(ShopContext context) : base(context)
        {
            this.context = context;
        }

        public void Edit(EditSlide slide)
        {
            
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
                CreationDate = x.CreationDate.ToFarsi(),
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
                PicturePath = x.Picture,
                Text = x.Text,
                CreationDate = x.CreationDate.ToFarsi(),
                BtnText =x.BtnText,
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Link = x.Link
            })
            .ToList();
        }

        public EditSlide GetDetail(long id)
        {
            return context.Slides.Select(x => new EditSlide
            {
                Title = x.Title,
                Heading = x.Heading,
                PicturePath = x.Picture,
                Text = x.Text,
                CreationDate = x.CreationDate.ToFarsi(),
                BtnText = x.BtnText,
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Link = x.Link
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
                    CreationDate = x.CreationDate.ToFarsi(),
                    IsRemoved = x.IsRemoved
                })
                .FirstOrDefault(x=>x.Id == id);
        }

        public Slide GetSlide(long id)
        {
            return context.Slides.Find(id);
        }
    }
}
