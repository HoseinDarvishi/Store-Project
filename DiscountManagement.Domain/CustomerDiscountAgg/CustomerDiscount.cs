using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountManagement.Domain.CustomerDiscountAgg
{
    public class CustomerDiscount
    {
        public long Id { get; private set; }

        public long ProductId { get; private set; }

        public int DiscountPercent { get; private set; }

        public string Reason { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime StartDate { get; private set; }

        public DateTime EndDate { get; private set; }

        public DateTime CreationDate { get; private set; }


        public CustomerDiscount(long productId, int discountPercent, string reason, DateTime startDate, DateTime endDate)
        {
            ProductId = productId;
            DiscountPercent = discountPercent;
            Reason = reason;
            StartDate = startDate;
            EndDate = endDate;
            IsActive = true;
            CreationDate = DateTime.Now;
        }

        public void Edit(long productId, int discountPercent, string reason, DateTime startDate, DateTime endDate)
        {
            ProductId = productId;
            DiscountPercent = discountPercent;
            Reason = reason;
            StartDate = startDate;
            EndDate = endDate;
        }

        public void Active()
        {
            IsActive = true;
        }

        public void DeActive()
        {
            IsActive = false;
        }
    }
}
