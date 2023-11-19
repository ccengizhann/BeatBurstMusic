using BeatBurstMusic.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeatBurstMusic.Persistance.Configuration
{
    public class InstrumentCategoryConfiguration : IEntityTypeConfiguration<InstrumentCategory>
    {
        public void Configure(EntityTypeBuilder<InstrumentCategory> builder)
        {
            builder.HasKey(x => new { x.InstrumentId, x.CategoryId });

            // Relationships
            builder.HasOne<Instrument>(x => x.Instrument)
                .WithMany(x => x.InstrumentCategories)
                .HasForeignKey(x => x.InstrumentId);

            builder.HasOne<Category>(x => x.Category)
                .WithMany(x => x.InstrumentCategories)
                .HasForeignKey(x => x.CategoryId);

            // Common Fields
            // Common Fields

            // CreatedByUserId
            builder.Property(x => x.CreatedByUserId).IsRequired();
            builder.Property(x => x.CreatedByUserId).HasMaxLength(75);

            // CreatedOn
            builder.Property(x => x.CreatedOn).IsRequired();

            builder.ToTable("InstrumentCategories");
        }
    }
}
