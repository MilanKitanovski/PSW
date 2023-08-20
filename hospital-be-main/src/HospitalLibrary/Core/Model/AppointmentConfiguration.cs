using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalLibrary.Core.Model
{
    public class AppointmentConfiguration : IEntityTypeConfiguration<Appointment>
    {
        public void Configure(EntityTypeBuilder<Appointment> builder)
        {
            builder.OwnsOne(usage => usage.Range, a =>
            {
                a.Property(prop => prop.StartTime)
                .HasColumnName("StartTime");
                a.Property(prop => prop.EndTime)
                .HasColumnName("EndTime");
            });
        }
    }
}
