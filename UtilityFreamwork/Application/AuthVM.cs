using System.Collections.Generic;

namespace UtilityFreamwork.Application
{
   public class AuthVM
   {
      public long Id { get; set; }
      public int RoleId { get; set; }
      public string Role { get; set; }
      public string Fullname { get; set; }
      public string Username { get; set; }
      public string Mobile { get; set; }
      public List<int> PermissionsCode { get; set; }

      public AuthVM()
      { }

      public AuthVM(long id, int roleId, string fullname, string username, List<int> permissionsCode)
      {
         Id = id;
         RoleId = roleId;
         Fullname = fullname;
         Username = username;
         PermissionsCode = permissionsCode;
      }
   }
}