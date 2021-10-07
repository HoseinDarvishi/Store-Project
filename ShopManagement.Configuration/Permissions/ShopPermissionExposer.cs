using System.Collections.Generic;
using UtilityFreamwork.Infra;

namespace ShopManagement.Configuration.Permissions
{
   public class ShopPermissionExposer : IPermissionExposer
   {
      public Dictionary<string, List<PermissionDto>> Expose()
      {
         return new Dictionary<string, List<PermissionDto>>
         {
            {
               "محصولات", new List<PermissionDto>
               {
                  new PermissionDto(ProductPermissions.ListProducts , "مشاهده لیست"),
                  new PermissionDto(ProductPermissions.SearchProduct , "جستجو در محصولات"),
                  new PermissionDto(ProductPermissions.CreateProduct , "ایجاد محصول "),
                  new PermissionDto(ProductPermissions.EditProduct , "ویرایش محصول")
               }
            },

            {
               "گروه محصولات", new List<PermissionDto>
               {
                  new PermissionDto(ProductCategoryPermissions.List , "مشاهده لیست گروه محصولات"),
                  new PermissionDto(ProductCategoryPermissions.Search , "جستجو در گروه ها"),
                  new PermissionDto(ProductCategoryPermissions.Create, "ایجاد گروه"),
                  new PermissionDto(ProductCategoryPermissions.Edit, "ویرایش گروه محصولات")
               }
            },

            {
               "اسلاید", new List<PermissionDto>
               {
                  new PermissionDto(SlidePermissions.List , "مشاهده لیست اسلایدها"),
                  new PermissionDto(SlidePermissions.Create, "ایجاد اسلاید"),
                  new PermissionDto(SlidePermissions.Edit, "ویرایش اسلاید"),
                  new PermissionDto(SlidePermissions.Delete, "حذف اسلاید")
               }
            },
            {
               "عکس محصولات", new List<PermissionDto>
               {
                  new PermissionDto(ProductPicturePermissions.List , "مشاهده لیست عکسها"),
                  new PermissionDto(ProductPicturePermissions.Create, "ایجاد عکس"),
                  new PermissionDto(ProductPicturePermissions.Edit, "ویرایش عکس"),
                  new PermissionDto(ProductPicturePermissions.Delete, "حذف عکس")
               }
            }
         };
      }
   }
}
