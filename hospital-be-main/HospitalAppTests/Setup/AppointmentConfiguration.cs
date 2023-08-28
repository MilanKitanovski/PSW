using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalAppTests.IntegrationTest
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
