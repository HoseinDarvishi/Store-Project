namespace UtilityFreamwork.Application
{
   public class AccountRoles
   {
      public const string User = "1";
      public const string Manager = "2";
      public const string ContentUploader = "3";
      public const string Inventor = "5";

      public static string GetRoleBy(long id)
      {
         switch (id)
         {
            case 1:
               return "کاربر";
            case 2:
               return "مدیر";
            case 3:
               return "محتواگذار";
            case 5:
               return "انباردار";
            default:
               return"";
         }
      }
   }
}
