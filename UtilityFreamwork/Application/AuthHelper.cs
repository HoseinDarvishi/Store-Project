using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace UtilityFreamwork.Application
{
   public class AuthHelper : IAuthHelper
   {
      private readonly IHttpContextAccessor _contextAccessor;

      public AuthHelper(IHttpContextAccessor contextAccessor)
      {
         _contextAccessor = contextAccessor;
      }

      public void SignIn(AuthVM account)
      {
         var permissions = JsonConvert.SerializeObject(account.PermissionsCode);
         var claims = new List<Claim>
            {
                new Claim("AccountId", account.Id.ToString()),
                new Claim(ClaimTypes.Name, account.Fullname),
                new Claim(ClaimTypes.Role, account.RoleId.ToString()),
                new Claim("Username", account.Username),                      // Or Use ClaimTypes.NameIdentifier
                new Claim("permissions", permissions),
                new Claim("Mobile", account.Mobile.ToString())
            };

         var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

         var authProperties = new AuthenticationProperties
         {
            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
         };

         _contextAccessor.HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(claimsIdentity),
            authProperties);
      }

      public AuthVM CurrentAccountInfo()
      {
         var res = new AuthVM();

         if (!IsAuthenticated())
            return res;

         res.Id =long.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "AccountId")?.Value);
         res.Fullname = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value;
         res.Username = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Username")?.Value;
         res.RoleId = int.Parse(_contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value);
         res.Mobile = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Mobile")?.Value;
         res.Role = AccountRoles.GetRoleBy(res.RoleId);

         return res;
      }

      public long CurrentAccountId()
      {
         if (IsAuthenticated())
            return long.Parse(_contextAccessor.HttpContext.User.Claims.First(x => x.Type == "AccountId")?.Value);
         return 0;
      }

      public string CurrentAccountRole()
      {
         if (IsAuthenticated())
            return _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
         return null;
      }

      public bool IsAuthenticated()
      {
         return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
      }

      public void SignOut()
      {
         _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
      }

      public List<int> GetPermissionCodes()
      {
         if (!IsAuthenticated())
            return new List<int>();
         var permission = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "permissions")?.Value;
         return JsonConvert.DeserializeObject<List<int>>(permission);
      }
   }
}