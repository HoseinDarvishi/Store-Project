using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using UtilityFreamwork.Application;

namespace AccountManagement.Application.Constracts.Account
{
   public class CreateAccount
   {
      [Required(ErrorMessage = "این مقدار الزامی است")]
      public string Fullname { get; set; }

      [Required(ErrorMessage = "این مقدار الزامی است")]
      public string Username { get; set; }

      [Required(ErrorMessage = "این مقدار الزامی است")]
      public string Password { get; set; }

      [Required(ErrorMessage = "این مقدار الزامی است")]
      public string Mobile { get; set; }

      [Required(ErrorMessage = "این مقدار الزامی است")]
      [MaxFileSize(1 * 1024 * 1024, ErrorMessage = "حجم تصویر بیشتر از 2 مگابایت است")]
      [FileExtention(new string[] { ".jpg", ".jpeg", ".png" } , ErrorMessage = "فرمت فایل پشتیبانی نمیشود")]
      public IFormFile Picture { get; set; }

      [Range(1,4)]
      public UserRole Role { get; set; }
   }
}
