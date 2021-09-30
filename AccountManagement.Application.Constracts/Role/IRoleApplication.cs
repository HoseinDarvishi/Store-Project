using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace AccountManagement.Application.Constracts.Role
{
   public interface IRoleApplication
   {
      GenerateResult Create(CreateRole command);
      GenerateResult Edit(EditRole command);
      List<EditRole> List();
      EditRole GetDetails(int id);
   }
}
