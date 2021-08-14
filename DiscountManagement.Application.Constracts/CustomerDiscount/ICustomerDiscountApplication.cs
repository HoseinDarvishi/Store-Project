using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace DiscountManagement.Application.Constracts.CustomerDiscount
{
    public interface ICustomerDiscountApplication
    {
        GenerateResult Create(CreateCustomerDiscount model);
        GenerateResult Edit(EditCustomerDiscount Editmodel);
        GenerateResult Active(long id);
        GenerateResult DeActive(long id);

        List<CustomerDiscountVM> Search(CustomerDiscountSearchModel searchModel);
        List<EditCustomerDiscount> GetAllDetails();

        EditCustomerDiscount GetDetail(long id);
    }
}
