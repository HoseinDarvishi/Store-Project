﻿using UtilityFreamwork.Repository;

namespace ShopManagement.Domain.OrderAgg
{
   public interface IOrderRepository : IRepository<long , Order>
   {
   }
}
