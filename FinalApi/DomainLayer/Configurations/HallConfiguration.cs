using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations
{
    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Place).IsRequired();
            builder.Property(m => m.Address).IsRequired();

        }
    }
}
