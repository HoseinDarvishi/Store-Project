using System;

namespace DiscountManagement.Application.Constracts.ColleagueDiscount
{
    public class ColleagueDiscountVM
    {
        public long Id { get; set; }

        public int DiscountPercent { get;  set; }

        public long ProductId { get;  set; }

        public string Product { get; set; }

        public bool IsActive { get;  set; }

        public string CreationDate { get;  set; }
    }
}
