using HospitalAPI.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class MenstrualConfiguration : IEntityTypeConfiguration<InternalData>
    {
        public void Configure(EntityTypeBuilder<InternalData> builder)
        {
            builder.OwnsOne(usage => usage.Menstrual, a =>
            {
                a.Property(prop => prop.StartTime)
                .HasColumnName("StartTime");
                a.Property(prop => prop.EndTime)
                .HasColumnName("EndTime");
            });
        }
    }
}
