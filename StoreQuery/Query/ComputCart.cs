using DiscountManagement.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Constract.Order;
using System.Collections.Generic;
using System.Linq;
using UtilityFreamwork.Application;

namespace StoreQuery.Query
{
   public class ComputCart : IComputCart
   {
      private readonly DiscountContext _discountContext;
      private readonly IAuthHelper _authHelper;

      public ComputCart(IAuthHelper authHelper , DiscountContext discountContext)
      {
         _authHelper = authHelper;
         _discountContext = discountContext;
      }

      public Cart CalcCart(List<CartItem> cartItems)
      {
         var cart = new Cart();

         var colDiscounts = _discountContext.ColleagueDiscounts
            .Where(X => X.IsActive)
            .Select(x => new { x.ProductId, x.DiscountPercent })
            .AsNoTracking()
            .ToList();

         var userDiscounts = _discountContext.CustomerDiscounts
            .Where(x => x.StartDate < System.DateTime.Now && x.EndDate > System.DateTime.Now)
            .Select(x => new { x.ProductId, x.DiscountPercent })
            .AsNoTracking()
            .ToList();

         if (_authHelper.CurrentAccountRole() == AccountRoles.Colleague)
         {
            foreach (var item in cartItems)
            {
               var discount = colDiscounts.FirstOrDefault(x => x.ProductId == item.Id);
               if (discount != null)
                  item.DiscountRate = discount.DiscountPercent;

               item.PriceWithDiscount = ((item.TotalPrice * item.DiscountRate) / 100);
               item.TotalPaymentPrice = item.TotalPrice - item.PriceWithDiscount;

               cart.Add(item);
            }
         }
         else
         {
            foreach (var item in cartItems)
            {
               var discount = userDiscounts.FirstOrDefault(x => x.ProductId == item.Id);
               if (discount != null)
                  item.DiscountRate = discount.DiscountPercent;

               item.PriceWithDiscount = ((item.TotalPrice * item.DiscountRate) / 100);
               item.TotalPaymentPrice = item.TotalPrice - item.PriceWithDiscount;

               cart.Add(item);
            }
         }

         return cart;
      }
   }

   public interface IComputCart
   {
      Cart CalcCart(List<CartItem> cartItems);
   }
}
