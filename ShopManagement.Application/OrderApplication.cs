﻿using ShopManagement.Application.Constract.Order;
using ShopManagement.Domain.OrderAgg;
using UtilityFreamwork.Application;

namespace ShopManagement.Application
{
   public class OrderApplication : IOrderApplication
   {
      private readonly IOrderRepository _orderRepository;
      private readonly IAuthHelper _authHelper;

      public OrderApplication(IOrderRepository orderRepository , IAuthHelper authHelper)
      {
         _orderRepository = orderRepository;
         _authHelper = authHelper;
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
         //We Should Reeduce From Inventory
         _orderRepository.Save();
         return trackingNumber;
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
   }
}
