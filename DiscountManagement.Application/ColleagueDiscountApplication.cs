using DiscountManagement.Application.Constracts.ColleagueDiscount;
using DiscountManagement.Domain.ColleagueDiscountAgg;
using System;
using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace DiscountManagement.Application
{
    public class ColleagueDiscountApplication : IColleagueDiscountApplication
    {
        private readonly IColleagueDiscountRepository repository;

        public ColleagueDiscountApplication(IColleagueDiscountRepository repository)
        {
            this.repository = repository;
        }

        public GenerateResult Create(CreateColleagueDiscount colleagueDiscount)
        {
            if (repository.IsExists(x => x.ProductId == colleagueDiscount.ProductId))
                return new GenerateResult().Failed("برای این محصول تخفیف همکاری وجود دارد");

            var coll = new ColleagueDiscount(colleagueDiscount.DiscountPercent, colleagueDiscount.ProductId);
            repository.Create(coll);
            repository.Save();
            return new GenerateResult().Succedded();
        }

        public GenerateResult Active(long id)
        {
            if (!repository.IsExists(x => x.Id == id))
                return new GenerateResult().Failed("برای همکاران چنین تخفیفی تعریف نشده است");

            repository.Active(id);
            repository.Save();
            return new GenerateResult().Succedded();
        }
        public GenerateResult DeActive(long id)
        {
            if (!repository.IsExists(x => x.Id == id))
                return new GenerateResult().Failed("برای همکاران چنین تخفیفی تعریف نشده است");

            repository.DeActive(id);
            repository.Save();
            return new GenerateResult().Succedded();
        }

        public GenerateResult Edit(EditColleagueDiscount colleagueDiscount)
        {
            if (!repository.IsExists(x => x.ProductId == colleagueDiscount.Id))
                return new GenerateResult().Failed("چنین تخفیفی برای همکاران وجود ندارد");

            if (repository.IsExists(x => x.ProductId == colleagueDiscount.ProductId && x.Id != colleagueDiscount.Id))
                return new GenerateResult().Failed("برای این محصول تخفیف همکاری وجود دارد");

            repository.Edit(colleagueDiscount);
            repository.Save();
            return new GenerateResult().Succedded();
        }

        public ColleagueDiscountVM Get(long id)
        {
            return repository.Get(id);
        }

        public EditColleagueDiscount GetDetail(long id)
        {
            return repository.GetDetail(id);
        }

        public List<ColleagueDiscountVM> Search(ColleagueDiscountSearchModel searchModel)
        {
            return repository.Search(searchModel);
        }
    }
}
