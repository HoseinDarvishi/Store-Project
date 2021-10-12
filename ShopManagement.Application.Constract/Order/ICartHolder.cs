namespace ShopManagement.Application.Constract.Order
{
   public interface ICartHolder
   {
      Cart Get();
      void Set(Cart cart);
   }
}
