using AccountManagement.Application.Constracts.Role;
using AccountManagement.Domain.RoleAgg;
using System.Collections.Generic;
using UtilityFreamwork.Application;

namespace AccountManagement.Application
{
   public class RoleApplication : IRoleApplication
   {
      private readonly IRoleRepository _repository;

      public RoleApplication(IRoleRepository repository)
      {
         _repository = repository;
      }

      public GenerateResult Create(CreateRole command)
      {
         if (_repository.IsExists(x => x.Name == command.Name))
            return new GenerateResult().Failed("قبلا با همین نام نقش دیگری اضافه شده است");

         var role = new Role(command.Name);
         _repository.create(role);
         _repository.Save();
         return new GenerateResult().Succedded();
      }
      public GenerateResult Edit(EditRole command)
      {
         var role = _repository.Get(command.Id);

         if (role == null)
            return new GenerateResult().Failed("چنین نقشی وجود ندارد");

         if (_repository.IsExists(x => x.Name == command.Name && x.Id != command.Id))
            return new GenerateResult().Failed("قبلا با همین نام نقش دیگری اضافه شده است");

         role.Edit(command.Name);
         _repository.Save();
         return new GenerateResult().Succedded();

      }
      public EditRole GetDetails(int id)
      {
         return _repository.GetDetails(id);
      }
      public List<EditRole> List()
      {
         return _repository.List();
      }
   }
}
