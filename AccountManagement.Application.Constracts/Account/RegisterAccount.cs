using AccountManagement.Application.Constracts.Role;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using UtilityFreamwork.Application;

namespace AccountManagement.Application.Constracts.Account
{
   public class RegisterAccount
   {
      [Required(ErrorMessage = "این مقدار الزامی است")]
      public string Fullname { get; set; }

      [Required(ErrorMessage = "این مقدار الزامی است")]
      public string Username { get; set; }

      [Required(ErrorMessage = "این مقدار الزامی است")]
      public string Password { get; set; }

      [Required(ErrorMessage = "این مقدار الزامی است")]
      public string RePassword { get; set; }

      [Required(ErrorMessage = "این مقدار الزامی است")]
      public string Mobile { get; set; }

      [MaxFileSize(1 * 1024 * 1024, ErrorMessage = "حجم تصویر بیشتر از 2 مگابایت است")]
      [FileExtention(new string[] { ".jpg", ".jpeg", ".png" } , ErrorMessage = "فرمت فایل پشتیبانی نمیشود")]
      public IFormFile Picture { get; set; }
      public int RoleId { get; set; }
      public List<EditRole> Roles { get; set; }
   }
}
