namespace ShopManagement.Application.Constract.Order
{
   public interface IOrderApplication
   {
      long PlaceOrder(Cart cart);
      void Pay(long orderId, long refId);
   }
}
