﻿namespace AccountManagement.Domain.RoleAgg
{
   public class Permission
   {
      public long Id { get;private set; }

      public int Code { get; private set; }

      public string Name { get; private set; }

      public int RoleId { get; private set; }

      public Role Role { get; private set; }


      public Permission(int code)
      {
         Code = code;
      }

      public Permission(int code, string name, int roleId)
      {
         Code = code;
         Name = name;
         RoleId = roleId;
      }
   }
}
