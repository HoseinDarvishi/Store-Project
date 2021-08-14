namespace DiscountManagement.Application.Constracts.CustomerDiscount
{
    public class CreateCustomerDiscount
    {
        public long ProductId { get;  set; }

        public int DiscountPercent { get;  set; }

        public string Reason { get;  set; }

        public string StartDate { get;  set; }

        public string EndDate { get;  set; }
    }
}
