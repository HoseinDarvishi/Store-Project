using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Linq;
using UtilityFreamwork.Application;

namespace ServiceHost
{
   [HtmlTargetElement(Attributes = "permission")]
   //[HtmlTargetElement(Attributes = "NeedPermission")]
   public class PermissionTagHelper : TagHelper
   {
      private readonly IAuthHelper _authHelper;

      public PermissionTagHelper(IAuthHelper authHelper)
      {
         _authHelper = authHelper;
      }

      public int Permission { get; set; }

      public override void Process(TagHelperContext context, TagHelperOutput output)
      {
         if (!_authHelper.IsAuthenticated())
         {
            output.SuppressOutput();
            return;
         }

         var permissions = _authHelper.GetPermissionCodes();
         if (permissions.All(x=>x != Permission))
         {
            output.SuppressOutput();
            return;
         }

         base.Process(context, output);
      }
   }
}
