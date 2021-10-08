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
                  new PermissionDto(ShopPermissions.ListProducts , "مشاهده لیست"),
                  new PermissionDto(ShopPermissions.SearchProduct , "جستجو در محصولات"),
                  new PermissionDto(ShopPermissions.CreateProduct , "ایجاد محصول "),
                  new PermissionDto(ShopPermissions.EditProduct , "ویرایش محصول")
               }
            },

            {
               "گروه محصولات", new List<PermissionDto>
               {
                  new PermissionDto(ShopPermissions.ListProductCategories , "مشاهده لیست گروه محصولات"),
                  new PermissionDto(ShopPermissions.SearchProductCategories , "جستجو در گروه ها"),
                  new PermissionDto(ShopPermissions.CreateProductCategory, "ایجاد گروه"),
                  new PermissionDto(ShopPermissions.EditProductCategory, "ویرایش گروه محصولات")
               }
            },

            {
               "اسلاید", new List<PermissionDto>
               {
                  new PermissionDto(ShopPermissions.ListSlides , "مشاهده لیست اسلایدها"),
                  new PermissionDto(ShopPermissions.CreateSlide, "ایجاد اسلاید"),
                  new PermissionDto(ShopPermissions.EditSlide, "ویرایش اسلاید"),
                  new PermissionDto(ShopPermissions.DeleteSlide, "حذف اسلاید"),
                  new PermissionDto(ShopPermissions.RestoreSlide, "بازگردانی اسلاید")
               }
            },

            {
               "عکس محصولات", new List<PermissionDto>
               {
                  new PermissionDto(ShopPermissions.ListProductPictures , "مشاهده لیست عکسها"),
                  new PermissionDto(ShopPermissions.CreateProductPictures, "ایجاد عکس"),
                  new PermissionDto(ShopPermissions.EditProductPictures, "ویرایش عکس"),
                  new PermissionDto(ShopPermissions.DeleteProductPictures, "حذف عکس")
               }
            },

            {
               "نظرات", new List<PermissionDto>
               {
                  new PermissionDto(ShopPermissions.ListProductComments , "مشاهده لیست نظرات محصولات"),
                  new PermissionDto(ShopPermissions.ChangeStatusProductComments, "تایید یا رد نظرات محصول")
               }
            }
         };
      }
   }
}
