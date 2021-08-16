using DiscountManagement.Application.Constracts.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using System.Collections.Generic;
using UtilityFreamwork.Repository;

namespace DiscountManagement.Application
{
    public interface IColleagueDiscountRepository : IRepository<long, ColleagueDiscount>
    {
        List<ColleagueDiscountVM> Search(ColleagueDiscountSearchModel searchModel);

        void Edit(EditColleagueDiscount editColleague);

        void Active(long id);
        void DeActive(long id);

        ColleagueDiscountVM Get(long id);

        EditColleagueDiscount GetDetail(long id);
    }
}
