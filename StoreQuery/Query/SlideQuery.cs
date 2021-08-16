using ShopManagement.Infrastructure.EFCore;
using StoreQuery.Slide;
using System.Collections.Generic;
using System.Linq;

namespace StoreQuery.Query
{
    public class SlideQuery : ISlideQuery
    {
        private readonly ShopContext context;

        public SlideQuery(ShopContext context)
        {
            this.context = context;
        }

        public List<SlideQM> GetSlides()
        {
            return context.Slides
                .Where(x => x.IsRemoved == false)
                .Select(x => new SlideQM 
                {
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    Heading = x.Heading,
                    Title = x.Title,
                    Text = x.Text,
                    BtnText = x.BtnText,
                    Link = x.Link
                })
                .ToList();
        }
    }
}
