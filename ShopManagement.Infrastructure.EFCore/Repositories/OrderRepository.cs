using AccountManagement.Infrastructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Constract.Order;
using ShopManagement.Domain.OrderAgg;
using System.Collections.Generic;
using System.Linq;
using UtilityFreamwork.Application;
using UtilityFreamwork.Repository;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
   public class OrderRepository : Repository<long , Order> , IOrderRepository
   {
      private readonly ShopContext _context;
      private readonly AccountContext _accountContext;

      public OrderRepository(ShopContext context , AccountContext accountContext) : base(context)
      {
         _context = context;
         _accountContext = accountContext;
      }

      public List<OrderItemViewModel> GetItems(long orderId)
      {
         var order = _context.Orders.AsNoTracking().FirstOrDefault(x => x.Id == orderId);
         if (order == null) return new List<OrderItemViewModel>();

         var items = order.Items.Select(x => new OrderItemViewModel 
         {
            ProductId = x.ProductId,
            Count = x.Count,
            OrderId = x.OrderId,
            DiscountRate = x.DiscountRate,
            UnitPrice = x.Price,
            TotalPrice = x.Price*x.Count,
            TotalDiscount = ((x.Price * x.Count)*(x.DiscountRate)/100),
         }).ToList();

         var products = _context.Products.AsNoTracking().Select(x => new { x.Id, x.Name }).ToList();

         foreach (var item in items)
         {
            item.TotalPayment = item.TotalPrice - item.TotalDiscount;
            item.ProductName = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
         }

         return items;
      }

      public double GetTotalPaymentPriceById(long id)
      {
         var order = _context.Orders.Select(x => new { x.TotalPaymentPrice, x.Id }).FirstOrDefault(x => x.Id == id);
         if (order != null)
            return order.TotalPaymentPrice;
         return 0;
      }

      public List<OrderViewModel> Search(OrderSearchModel searchModel)
      {
         var accounts = _accountContext.Accounts.Select(x => new { x.Id, x.Fullname }).ToList();
         var query = _context.Orders.Select(x => new OrderViewModel 
         {
            Id = x.Id,
            AccountId = x.AccountId,
            IsCanceled = x.IsCanceled,
            IsPaid = x.IsPaid,
            TotalPrice = x.TotalPrice.ToString("#,#"),
            TotalPayment = x.TotalPaymentPrice.ToString("#,#"),
            TotalDiscount = x.TotalPriceWithDiscount.ToString("#,#"),
            RegisterDate = x.RegisterDate.ToFarsi(),
            RefId = x.RefId,
            TrackingNumber = x.TrackNumber
         });

         if (searchModel.IsCanceled)
            query = query.Where(x => x.IsCanceled);
         if (searchModel.IsPaid)
            query = query.Where(x => x.IsPaid);
         if (searchModel.AccountId > 0)
            query = query.Where(x => x.AccountId == searchModel.AccountId);

         var orders = query.OrderByDescending(x => x.Id).ToList();

         orders.ForEach(order => { order.AccountFullName = accounts.FirstOrDefault(x => x.Id == order.AccountId)?.Fullname; });

         return orders;
      }
   }
}
