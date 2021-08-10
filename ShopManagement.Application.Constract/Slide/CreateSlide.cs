using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Constract.Slide
{
    public class CreateSlide
    {
        [Required(ErrorMessage = "مسیر عکس الزامی است")]
        public string Picture { get; set; }

        [Required(ErrorMessage = "متن جایگزین عکس الزامی است")]
        public string PictureAlt { get; set; }

        [Required(ErrorMessage = "عنوان عکس الزامی است")]
        public string PictureTitle { get; set; }

        [Required(ErrorMessage = "سر تیتر اسلاید الزامی است")]
        public string Heading { get; set; }

        public string Title { get; set; }

        [Required(ErrorMessage = "متن اسلاید الزامی است")]
        public string Text { get; set; }

        [Required(ErrorMessage = "متن دکمه الزامی است")]
        public string BtnText { get; set; }
    }
}
