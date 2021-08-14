namespace DiscountManagement.Application.Constracts.CustomerDiscount
{
    public class EditCustomerDiscount
    {
        public long Id { get; set; }

        public long ProductId { get; set; }

        public int DiscountPercent { get; set; }

        public string Reason { get; set; }

        public string StartDate { get; set; }

        public string EndDate { get; set; }
    }
}
