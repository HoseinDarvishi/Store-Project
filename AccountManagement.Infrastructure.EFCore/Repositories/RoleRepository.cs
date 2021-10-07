using AccountManagement.Application.Constracts.Role;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using UtilityFreamwork.Application;
using UtilityFreamwork.Infra;
using UtilityFreamwork.Repository;

namespace AccountManagement.Infrastructure.EFCore.Repositories
{
   public class RoleRepository : Repository<int, Role>, IRoleRepository
   {
      private readonly AccountContext _context;

      public RoleRepository(AccountContext context) :base(context)
      {
         _context = context;
      }

      public void create(Role role)
      {
         _context.Roles.Add(role);
         Save();
      }

      public EditRole GetDetails(int id)
      {
         var role = _context.Roles.Select(x=> new EditRole 
         {
            Id = x.Id,
            Name = x.Name,
            MappedPermissions = MapPermissions(x.Permissions),
            CreationDate = x.CreationDate.ToFarsi()
         }).AsNoTracking().FirstOrDefault(x => x.Id == id);

         role.PermissionsCode = role.MappedPermissions.Select(x => x.Code).ToList();

         return role;
      }

      public List<EditRole> List()
      {
         return _context.Roles.Select(x => new EditRole
         {
            Id = x.Id,
            Name = x.Name,
            MappedPermissions = MapPermissions(x.Permissions),
            CreationDate = x.CreationDate.ToFarsi()
         }).AsNoTracking().OrderBy(x=>x.Id).ToList();
      }

      private static List<PermissionDto> MapPermissions(List<Permission> permissions)
      {
         return permissions.Select(x => new PermissionDto(x.Code, x.Name)).ToList();
      }
   }
}
