using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Constracts.Role
{
   public class CreateRole
   {
      [Required(ErrorMessage = "نام نقش جدید را وارد کنید")]
      public string Name { get; set; }
      public List<int> PermissionsCode { get; set; }
   }
}
