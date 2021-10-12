namespace ShopManagement.Application.Constract.Order
{
   public class CartHolder : ICartHolder
   {
      public Cart Cart { get; set; }

      public Cart Get()
      {
         return Cart;
      }

      public void Set(Cart cart)
      {
         Cart = cart;
      }
   }
}
