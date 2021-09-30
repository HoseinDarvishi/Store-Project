using AccountManagement.Application.Constracts.Role;
using System.Collections.Generic;
using UtilityFreamwork.Repository;

namespace AccountManagement.Domain.RoleAgg
{
   public interface IRoleRepository : IRepository<int, Role>
   {
      List<EditRole> List();
      EditRole GetDetails(int id);
      void create(Role role);
   }
}
