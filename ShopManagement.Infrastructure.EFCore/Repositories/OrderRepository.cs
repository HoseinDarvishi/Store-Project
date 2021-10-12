using ShopManagement.Domain.OrderAgg;
using System.Collections.Generic;
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
   }
}
