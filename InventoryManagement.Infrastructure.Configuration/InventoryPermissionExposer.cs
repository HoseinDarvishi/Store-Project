using System;
using System.Collections.Generic;
using UtilityFreamwork.Infra;

namespace InventoryManagement.Infrastructure.Configuration
{
   public class InventoryPermissionExposer : IPermissionExposer
   {
      public Dictionary<string, List<PermissionDto>> Expose()
      {
         return new Dictionary<string, List<PermissionDto>>
         {
            {
               "انبار", new List<PermissionDto>
               {
                  new PermissionDto(InventoryPermissions.ListInventories , "مشاهده لیست انبار"),
                  new PermissionDto(InventoryPermissions.SearchInventories , "جستجو در انبار"),
                  new PermissionDto(InventoryPermissions.CreateInventory , "ایجاد انبار "),
                  new PermissionDto(InventoryPermissions.EditInventory , "ویرایش انبار"),
                  new PermissionDto(InventoryPermissions.ReduceInventory , "کاهش موجودی انبار"),
                  new PermissionDto(InventoryPermissions.IncreaseInventory , "افزایش موجودی انبار")
               }
            }
         };
      }
   }
}
