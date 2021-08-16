using DiscountManagement.Domain.ColleagueDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DiscountManagement.Infrastructure.Mapping
{
    public class ColleaugeDiscountMapping : IEntityTypeConfiguration<ColleagueDiscount>
    {
        public void Configure(EntityTypeBuilder<ColleagueDiscount> b)
        {
            b.ToTable("ColleagueDiscounts");
            b.HasKey(x => x.Id);
        }
    }
}
