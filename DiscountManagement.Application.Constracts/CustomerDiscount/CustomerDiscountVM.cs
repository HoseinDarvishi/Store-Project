using System;

namespace DiscountManagement.Application.Constracts.CustomerDiscount
{
    public class CustomerDiscountVM
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public string Product { get; set; }

        public int DiscountPercent { get; set; }

        public string Reason { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }

        public DateTime StartDateEN { get; set; }

        public DateTime EndDateEN { get; set; }
    }
}
