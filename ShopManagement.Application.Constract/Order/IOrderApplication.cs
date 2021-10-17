using System.Collections.Generic;

namespace ShopManagement.Application.Constract.Order
{
   public interface IOrderApplication
   {
      long PlaceOrder(Cart cart);
      string Pay(long orderId, long refId);
      double GetTotalPaymentPriceById(long id);
      List<OrderViewModel> Search(OrderSearchModel searchModel);
      void Cancel(long id);
      void Restore(long id);
      List<OrderItemViewModel> GetItemsBy(long orderId);
   }
}
