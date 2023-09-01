using System.Reflection;
using System.Xml;
using HospitalAPI.Model;
using HospitalLibrary.Core.Model;
using Microsoft.EntityFrameworkCore;

namespace HospitalLibrary.Settings
{
    public class HospitalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<InternalData> InternalDatas { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Direction> Directions { get; set; }
        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<Report> Reports { get; set; }
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<User>()
                 .Ignore(u => u.SuspiciousActivities)
                 .Property("suspicious_activities");

           

        }
    }
}
