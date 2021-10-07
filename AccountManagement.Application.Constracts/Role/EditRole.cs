using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UtilityFreamwork.Infra;

namespace AccountManagement.Application.Constracts.Role
{
   public class EditRole
   {
      public int Id { get; set; }
      [Required(ErrorMessage = "نام نقش را وارد کنید")]
      public string Name { get; set; }
      public List<PermissionDto> MappedPermissions { get; set; } = new List<PermissionDto>();
      public List<int> PermissionsCode { get; set; } = new List<int>();
      public string CreationDate { get; set; }
   }
}
