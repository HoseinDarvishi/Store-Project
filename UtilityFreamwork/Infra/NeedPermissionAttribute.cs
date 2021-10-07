using System;

namespace UtilityFreamwork.Infra
{
   public class NeedPermissionAttribute : Attribute
   {
      public int PermissionCode { get; set; }

      public NeedPermissionAttribute(int permissionCode)
      {
         PermissionCode = permissionCode;
      }
   }
}
