using AccountManagement.Domain.RoleAgg;
using System;

namespace AccountManagement.Domain.AccountAgg
{
   public class Account
   {
      public long Id { get; private set; }

      public string Fullname { get; private set; }

      public string Username { get; private set; }

      public string Password { get; private set; }

      public string Mobile { get; private set; }

      public string Picture { get; private set; }

      public sbyte RoleId { get;private set; }

      public Role Role { get; private set; }

      public DateTime CreationDate { get; private set; }


      public Account(string fullname, string username, string password, string mobile, string picture, sbyte roleId)
      {
         Fullname = fullname;
         Username = username;
         Password = password;
         Mobile = mobile;

         if (!string.IsNullOrWhiteSpace(picture))
            Picture = picture;
         else
            Picture = "ProfilePhotos/User-Icon.png";

         RoleId = roleId;
         CreationDate = DateTime.Now;
      }

      public void Edit(string fullname, string username, string mobile, string picture, sbyte roleId)
      {
         Fullname = fullname;
         Username = username;
         Mobile = mobile;

         if (!string.IsNullOrWhiteSpace(picture))
            Picture = picture;

         RoleId = roleId;
         CreationDate = DateTime.Now;
      }

      public void Upgrade(sbyte roleId)
      {
         RoleId = roleId;
      }

      public void ChangePassword(string password)
      {
         Password = password;
      }

      public void ChangeUsername(string username)
      {
         Username = username;
      }
   }
}
