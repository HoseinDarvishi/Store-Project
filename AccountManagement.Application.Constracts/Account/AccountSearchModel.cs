using UtilityFreamwork.Application;

namespace AccountManagement.Application.Constracts.Account
{
   public class AccountSearchModel 
   {
      public string Fullname { get; set; }

      public string Username { get; set; }

      public string Mobile { get; set; }

      public UserRole Role { get; set; }
   }
}
