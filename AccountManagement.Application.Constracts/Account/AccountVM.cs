
using UtilityFreamwork.Application;

namespace AccountManagement.Application.Constracts.Account
{
   public class AccountVM
   {
      public string Fullname { get; set; }

      public string Username { get; set; }

      public string Mobile { get; set; }

      public string Picture { get; set; }

      public UserRole Role { get; set; }

      public string RoleName { get; set; }

      public string SignInDate { get; set; }
      public long Id { get; set; }
   }
}
