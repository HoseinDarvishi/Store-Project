using ShopManagement.Application.Constract.Slide;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Domain.SlideAgg
{
    public interface ISlideRepository : IGenericRepository<long , Slide>
    {
        void Edit(EditSlide slide);

        List<EditSlide> GetAllDetail();

        SlideVM Get(long id);

        List<SlideVM> GetAll();

        EditSlide GetDetail(long id);

        void Remove(long id);

        void Restore(long id);
    }
}
