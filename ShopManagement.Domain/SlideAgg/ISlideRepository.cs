using ShopManagement.Application.Constract.Slide;
using System.Collections.Generic;

namespace ShopManagement.Domain.SlideAgg
{
   public interface ISlideRepository : IGenericRepository<long , Slide>
    {
        void Edit(EditSlide slide);

        List<EditSlide> GetAllDetail();

        SlideVM Get(long id);

        List<SlideVM> GetAll();

        Slide GetSlide(long id);

        EditSlide GetDetail(long id);

        void Remove(long id);

        void Restore(long id);
    }
}
