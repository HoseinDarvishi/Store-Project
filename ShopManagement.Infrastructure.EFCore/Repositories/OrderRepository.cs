using ShopManagement.Domain.OrderAgg;
using System.Linq;
using UtilityFreamwork.Repository;

namespace ShopManagement.Infrastructure.EFCore.Repositories
{
   public class OrderRepository : Repository<long , Order> , IOrderRepository
   {
      private readonly ShopContext _context;

      public OrderRepository(ShopContext context) : base(context)
      {
         _context = context;
      }

      public double GetTotalPaymentPriceById(long id)
      {
         var order = _context.Orders.Select(x => new { x.TotalPaymentPrice, x.Id }).FirstOrDefault(x => x.Id == id);
         if (order != null)
            return order.TotalPaymentPrice;
         return 0;
      }
   }
}
