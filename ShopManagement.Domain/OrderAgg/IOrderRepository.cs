using ShopManagement.Application.Constract.Order;
using System.Collections.Generic;
using UtilityFreamwork.Repository;

namespace ShopManagement.Domain.OrderAgg
{
   public interface IOrderRepository : IRepository<long , Order>
   {
      double GetTotalPaymentPriceById(long id);
      List<OrderViewModel> Search(OrderSearchModel searchModel);
      List<OrderItemViewModel> GetItems(long orderId);
   }
}
