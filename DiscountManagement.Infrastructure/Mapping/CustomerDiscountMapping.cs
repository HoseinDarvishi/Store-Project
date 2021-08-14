using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscountManagement.Infrastructure.Mapping
{
    public class CustomerDiscountMapping : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> b)
        {
            b.ToTable("CustomerDiscounts");
            b.HasKey(x => x.Id);

            b.Property(x => x.Reason).HasMaxLength(600);
        }
    }
}
