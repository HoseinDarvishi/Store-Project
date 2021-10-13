namespace ShopManagement.Application.Constract.Order
{
   public interface IOrderApplication
   {
      long PlaceOrder(Cart cart);
      string Pay(long orderId, long refId);
      double GetTotalPaymentPriceById(long id);
   }
}
