using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UtilityFreamwork.Infra;

namespace AccountManagement.Infrastructure.Configuration
{
   public class AccountPermissionExposer : IPermissionExposer
   {
      public Dictionary<string, List<PermissionDto>> Expose()
      {
         return new Dictionary<string, List<PermissionDto>>
         {
            {
               "کاربران", new List<PermissionDto>
               {
                  new PermissionDto(ShopPermissions.ListAccounts , "مشاهده لیست کاربران"),
                  new PermissionDto(ShopPermissions.CreateAccount , "ایجاد کاربر"),
                  new PermissionDto(ShopPermissions.EditAccount , "ویرایش کاربر"),
                  new PermissionDto(ShopPermissions.ChangePasswordAccount , "تغییر رمز کاربر")
               }
            },
            {
               "نقشهای کاربری", new List<PermissionDto>
               {
                  new PermissionDto(ShopPermissions.ListRoles , "مشاهده لیست نقشهای کاربری"),
                  new PermissionDto(ShopPermissions.CreateRole , "ایجاد نقش"),
                  new PermissionDto(ShopPermissions.EditRole , "ویرایش نقش")
               }
            }
         };
      }
   }
}
