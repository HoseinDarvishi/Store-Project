using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountManagement.Domain.ColleagueDiscountAgg
{
    public class ColleagueDiscount
    {
        public long Id { get; private set; }

        public int DiscountPercent { get; private set; }

        public long ProductId { get; private set; }

        public bool IsActive { get; private set; }

        public DateTime CreationDate { get; private set; }

        public ColleagueDiscount(int discountPercent, long productId)
        {
            DiscountPercent = discountPercent;
            ProductId = productId;
            IsActive = true;
            CreationDate = DateTime.Now;
        }

        public void Edit(int discountPercent, long productId)
        {
            DiscountPercent = discountPercent;
            ProductId = productId;
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
