using ShopManagement.Application.Constract.Order;
using ShopManagement.Domain.ACL_Services;
using ShopManagement.Domain.OrderAgg;
using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace ShopManagement.Application
{
   public class OrderApplication : IOrderApplication
   {
      private readonly IOrderRepository _orderRepository;
      private readonly IAuthHelper _authHelper;
      private readonly IShopInventoryACL _inventoryACL;

      public OrderApplication(IOrderRepository orderRepository , IAuthHelper authHelper , IShopInventoryACL inventoryACL)
      {
         _orderRepository = orderRepository;
         _authHelper = authHelper;
         _inventoryACL = inventoryACL;
      }

      public void Cancel(long id)
      {
         var order = _orderRepository.Get(id);
         order.Cancel();
         _orderRepository.Save();
      }

      public List<OrderItemViewModel> GetItemsBy(long orderId)
      {
         return _orderRepository.GetItems(orderId);
      }

      public double GetTotalPaymentPriceById(long id)
      {
         return _orderRepository.GetTotalPaymentPriceById(id);
      }

      public string Pay(long orderId, long refId)
      {
         var order = _orderRepository.Get(orderId);
         order.Payed(refId);
         var trackingNumber = CodeGenerator.Generate("R");
         order.SetTrackingNumber(trackingNumber);

         if (_inventoryACL.ReduceFromInventory(order.Items))
         {
            _orderRepository.Save();
            return trackingNumber;
         }
         return "";
      }

      public long PlaceOrder(Cart cart)
      {
         var accId = _authHelper.CurrentAccountId();

         var order = new Order(accId, cart.TotalPrice, cart.TotalPayment, cart.TotalWithDiscount);

         foreach (var item in cart.Items)
         {
            var orderItem = new OrderItem(item.Id, item.Count, item.Price, item.DiscountRate);
            order.AddItem(orderItem);
         }

         _orderRepository.Create(order);
         _orderRepository.Save();
         return order.Id;
      }

      public void Restore(long id)
      {
         var order = _orderRepository.Get(id);
         order.Restore();
         _orderRepository.Save();
      }

      public List<OrderViewModel> Search(OrderSearchModel searchModel)
      {
         return _orderRepository.Search(searchModel);
      }
   }
}
