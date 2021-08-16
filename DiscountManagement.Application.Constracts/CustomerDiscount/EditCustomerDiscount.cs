using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace DiscountManagement.Application.Constracts.CustomerDiscount
{
    public class EditCustomerDiscount
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "محصول را انتخاب کنید")]
        public long ProductId { get; set; }

        [Range(1, 100, ErrorMessage = "درصد تخفیف را وارد کنید")]
        public int DiscountPercent { get; set; }

        public string Reason { get; set; }

        [Required(ErrorMessage = "تاریخ شروع را وارد کنید")]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "تاریخ پایان را وارد کنید")]
        public string EndDate { get; set; }

        public IList Products { get; set; }
    }
}
