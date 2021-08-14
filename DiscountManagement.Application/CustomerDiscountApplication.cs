using DiscountManagement.Application.Constracts.CustomerDiscount;
using DiscountManagement.Domain.CustomerDiscountAgg;
using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace DiscountManagement.Application
{
    public class CustomerDiscountApplication : ICustomerDiscountApplication
    {
        private readonly ICustomerDiscoutRepository customerDiscount;

        public CustomerDiscountApplication(ICustomerDiscoutRepository customerDiscount)
        {
            this.customerDiscount = customerDiscount;
        }

        public GenerateResult Create(CreateCustomerDiscount model)
        {
            if (customerDiscount.IsExists(x => x.ProductId == model.ProductId && x.Reason == model.Reason && x.DiscountPercent == model.DiscountPercent))
                return new GenerateResult().Failed("این تخفیف قبلا ایجاد شده است"); 

            var newCus = new CustomerDiscount(model.ProductId, model.DiscountPercent, model.Reason, model.StartDate.ToGeorgianDateTime(), model.EndDate.ToGeorgianDateTime());

            customerDiscount.Create(newCus);
            customerDiscount.Save();

            return new GenerateResult().Succedded();
        }

        public GenerateResult Edit(EditCustomerDiscount Editmodel)
        {
            if (!customerDiscount.IsExists(x => x.Id == Editmodel.Id))
                return new GenerateResult().Failed("چنین تخفیفی وجود ندارد");

            if (customerDiscount.IsExists(x => x.Reason == Editmodel.Reason && x.DiscountPercent == Editmodel.DiscountPercent && Editmodel.Id != x.Id))
                return new GenerateResult().Failed("این تخفیف قبلا ایجاد شده است");

            customerDiscount.Edit(Editmodel);
            customerDiscount.Save();
            return new GenerateResult().Succedded();
        }

        public GenerateResult Active(long id)
        {
            if (!customerDiscount.IsExists(x => x.Id == id))
                return new GenerateResult().Failed("چنین تخفیفی وجود ندارد");

            customerDiscount.Active(id);
            customerDiscount.Save();
            return new GenerateResult().Succedded();
        }

        public GenerateResult DeActive(long id)
        {
            if (!customerDiscount.IsExists(x => x.Id == id))
                return new GenerateResult().Failed("چنین تخفیفی وجود ندارد");

            customerDiscount.DeActive(id);
            customerDiscount.Save();
            return new GenerateResult().Succedded();
        }

        public List<CustomerDiscountVM> Search(CustomerDiscountSearchModel searchModel)
        {
            return customerDiscount.Search(searchModel);
        }

        public List<EditCustomerDiscount> GetAllDetails()
        {
            return customerDiscount.GetAllDetails();
        }

        public EditCustomerDiscount GetDetail(long id)
        {
            return customerDiscount.GetDetail(id);
        }
    }
}
