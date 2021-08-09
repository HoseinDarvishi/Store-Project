using System;
using System.Collections.Generic;
using System.Text;
using UtilityFreamwork.Application;

namespace ShopManagement.Application.Constract.Slide
{
    public interface ISlideApplication 
    {
        GenerateResult Create(CreateSlide slide);

        GenerateResult Edit(EditSlide slide);

        GenerateResult Remove(long id);

        GenerateResult Restore(long id);

        SlideVM Get(long id);

        EditSlide GetDetail(long id);

        List<SlideVM> GetAll();

        List<EditSlide> GetAllDetails();
    }
}
