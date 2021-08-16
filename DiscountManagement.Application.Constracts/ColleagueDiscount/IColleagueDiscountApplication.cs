using System;
using System.Collections.Generic;
using System.Text;
using UtilityFreamwork.Application;

namespace DiscountManagement.Application.Constracts.ColleagueDiscount
{
    public interface IColleagueDiscountApplication
    {
        GenerateResult Create(CreateColleagueDiscount colleagueDiscount);

        GenerateResult Edit(EditColleagueDiscount colleagueDiscount);

        GenerateResult Active(long id);

        GenerateResult DeActive(long id);

        List<ColleagueDiscountVM> Search(ColleagueDiscountSearchModel searchModel);

        ColleagueDiscountVM Get(long id);

        EditColleagueDiscount GetDetail(long id);
    }
}
