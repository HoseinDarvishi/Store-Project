using System.ComponentModel.DataAnnotations;

namespace AccountManagement.Application.Constracts.Role
{
   public class EditRole
   {
      public int Id { get; set; }
      [Required(ErrorMessage = "نام نقش را وارد کنید")]
      public string Name { get; set; }
      public string CreationDate { get; set; }
   }
}
