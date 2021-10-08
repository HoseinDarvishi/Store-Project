using System.Collections.Generic;
using UtilityFreamwork.Infra;

namespace BlogManagement.Infrastracture.Configuration
{
   public class BlogPermissionExposer : IPermissionExposer
   {
      public Dictionary<string, List<PermissionDto>> Expose()
      {
         return new Dictionary<string, List<PermissionDto>>
         {
            {
               "مقالات", new List<PermissionDto>
               {
                  new PermissionDto(ShopPermissions.ListArticles , "مشاهده لیست مقالات"),
                  new PermissionDto(ShopPermissions.CreateArticle , "ایجاد مقاله"),
                  new PermissionDto(ShopPermissions.EditArticle , "ویرایش مقاله"),
                  new PermissionDto(ShopPermissions.RemoveArticle , "حذف مقاله"),
                  new PermissionDto(ShopPermissions.RestoreArticle , "بازگردانی مقاله")
               }
            },
            {
               "گروه مقالات", new List<PermissionDto>
               {
                  new PermissionDto(ShopPermissions.ListArticleCategory , "مشاهده لیست گروه مقالات"),
                  new PermissionDto(ShopPermissions.CreateArticleCategory , "ایجاد گروه مقاله"),
                  new PermissionDto(ShopPermissions.EditArticleCateory , "ویرایش گروه مقاله")
               }
            },
            {
               "نظرات مقالات", new List<PermissionDto>
               {
                  new PermissionDto(ShopPermissions.ListArticleComments , "مشاهده لیست نظرات مقاله"),
                  new PermissionDto(ShopPermissions.ChangeStatusArticleComments , "تغییر وضعیت نظرات مقالات")
               }
            }
         };
      }
   }
}
