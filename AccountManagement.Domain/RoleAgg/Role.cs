using AccountManagement.Domain.AccountAgg;
using System;
using System.Collections.Generic;

namespace AccountManagement.Domain.RoleAgg
{
   public class Role
   {
      public int Id { get;private set; }

      public string Name { get;private set; }

      public DateTime CreationDate { get;private set; }

      public List<Account> Accounts { get;private set; }

      public List<Permission> Permissions { get;private set; }

      protected Role()
      {

      }

      public Role(string name , List<Permission> permissions)
      {
         Name = name;
         Accounts = new List<Account>();
         CreationDate = DateTime.Now;
         Permissions = permissions;
      }

      public void Edit(string name ,List<Permission> permissions)
      {
         Name = name;
         Permissions = permissions;
      }
   }
}
