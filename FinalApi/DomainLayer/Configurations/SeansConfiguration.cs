using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DomainLayer.Configurations
{
    public class SeansConfiguration : IEntityTypeConfiguration<Seans>
    {
        public void Configure(EntityTypeBuilder<Seans> builder)
        {
            builder.Property(m => m.Name).IsRequired();
            builder.Property(m => m.Hour).IsRequired();


        }
    }
}
