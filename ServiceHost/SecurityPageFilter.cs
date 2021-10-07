using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using UtilityFreamwork.Application;
using UtilityFreamwork.Infra;

namespace ServiceHost
{
   public class SecurityPageFilter : IPageFilter
   {
      private readonly IAuthHelper _authHelper;

      public SecurityPageFilter(IAuthHelper authHelper)
      {
         _authHelper = authHelper;
      }

      public void OnPageHandlerExecuting(PageHandlerExecutingContext context)
      {
         var permission = (NeedPermissionAttribute)context.HandlerMethod.MethodInfo.GetCustomAttribute(typeof(NeedPermissionAttribute));

         if (permission == null)
            return;

         var permissinCodes = _authHelper.GetPermissionCodes();

         if (permissinCodes.All(x=> x != permission.PermissionCode))
            context.HttpContext.Response.Redirect("/NotFound");
      }

      public void OnPageHandlerExecuted(PageHandlerExecutedContext context)
      {
      }
      public void OnPageHandlerSelected(PageHandlerSelectedContext context)
      {
      }
   }
}
