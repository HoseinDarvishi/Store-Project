using AccountManagement.Domain.AccountAgg;
using System;
using System.Collections.Generic;

namespace AccountManagement.Domain.RoleAgg
{
   public class Role
   {
      public sbyte Id { get; set; }

      public string Name { get; set; }

      public DateTime CreationDate { get; set; }

      public List<Account> Accounts { get; set; }


      public Role(string name)
      {
         Name = name;
         CreationDate = DateTime.Now;
      }

      public void Edit(string name)
      {
         Name = name;
      }
   }
}
