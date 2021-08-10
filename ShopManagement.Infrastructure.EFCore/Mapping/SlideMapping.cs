using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShopManagement.Infrastructure.EFCore.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> b)
        {
            b.ToTable("Slides");
            b.HasKey(x => x.Id);

            b.Property(x => x.Picture).HasMaxLength(500).IsRequired();
            b.Property(x => x.PictureAlt).HasMaxLength(255).IsRequired();
            b.Property(x => x.PictureTitle).HasMaxLength(255).IsRequired();
            b.Property(x => x.Heading).HasMaxLength(100).IsRequired();
            b.Property(x => x.Title).HasMaxLength(255);
            b.Property(x => x.Text).HasMaxLength(500).IsRequired();
            b.Property(x => x.BtnText).HasMaxLength(20).IsRequired();
            b.Property(x => x.Link).HasMaxLength(1000).IsRequired();
        }
    }
}
