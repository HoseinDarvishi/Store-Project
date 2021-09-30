namespace UtilityFreamwork.Application
{
   public interface IAuthHelper
   {
      void SignIn(AuthVM account);
      void SignOut();
      bool IsAuthenticated();
   }
}
