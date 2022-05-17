using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
