using System.Collections.Generic;
using UtilityFreamwork.Infra;

namespace DiscountManagement.Configuration
{
   public class DiscountPermissionExposer : IPermissionExposer
   {
      public Dictionary<string, List<PermissionDto>> Expose()
      {
         return new Dictionary<string, List<PermissionDto>>
         {
            {
               "تخفیفات",new List<PermissionDto>
               {
                  new PermissionDto(ShopPermissions.ListDiscount , "مشاهده لیست تخفیفات"),
                  new PermissionDto(ShopPermissions.DefineDiscount , "تعریف تخفیف"),
                  new PermissionDto(ShopPermissions.EditDiscount , "ویرایش تخفیف"),
                  new PermissionDto(ShopPermissions.ActiveDiscount , "فعالسازی تخفیف"),
                  new PermissionDto(ShopPermissions.DeActiveDiscount , "غیرفعالسازی تخفیف")
               }
            }
         };
      }
   }
}
