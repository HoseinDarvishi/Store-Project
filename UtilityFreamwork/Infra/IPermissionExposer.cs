using System.Collections.Generic;

namespace UtilityFreamwork.Infra
{
   public interface IPermissionExposer
   {
      Dictionary<string, List<PermissionDto>> Expose();
   }

   public class PermissionDto
   {
      public int Code { get; set; }
      public string Name { get; set; }

      public PermissionDto(int code, string name)
      {
         Code = code;
         Name = name;
      }
   }
}
