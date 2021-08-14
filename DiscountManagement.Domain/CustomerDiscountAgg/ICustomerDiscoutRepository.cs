using DiscountManagement.Application.Constracts.CustomerDiscount;
using System.Collections.Generic;
using UtilityFreamwork.Repository;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public interface ICustomerDiscoutRepository : IRepository<long , CustomerDiscount>
    {
        void Edit(EditCustomerDiscount editCustomer);
        void Active(long id);
        void DeActive(long id);
        List<EditCustomerDiscount> GetAllDetails();
        List<CustomerDiscountVM> Search(CustomerDiscountSearchModel searchModel);
        EditCustomerDiscount GetDetail(long id);
    }
}
