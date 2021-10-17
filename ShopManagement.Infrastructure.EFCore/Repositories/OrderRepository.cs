using AccountManagement.Infrastructure.EFCore;
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
