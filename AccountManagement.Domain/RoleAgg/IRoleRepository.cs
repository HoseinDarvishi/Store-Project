using AccountManagement.Application.Constracts.Role;
using System.Collections.Generic;
using UtilityFreamwork.Repository;

namespace AccountManagement.Domain.RoleAgg
{
   public interface IRoleRepository : IRepository<sbyte , Role>
   {
      List<EditRole> List();
      EditRole GetDetails(sbyte id);
   }
}
