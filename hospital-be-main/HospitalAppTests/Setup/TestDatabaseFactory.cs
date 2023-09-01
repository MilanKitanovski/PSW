using HospitalAPI;
using HospitalAPI.Enum;
using HospitalAPI.Model;
using HospitalLibrary.Core.Enum;
using HospitalLibrary.Core.Model;
using HospitalLibrary.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppTests.Setup
{
    public class TestDatabaseFactory<TStartup> : WebApplicationFactory<Startup>
    {
        private static bool isDbCreated = false;
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseSolutionRelativeContentRoot("");

            builder.ConfigureServices(services =>
            {
                using var scope = BuildServiceProvider(services).CreateScope();
                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<HospitalDbContext>();

                InitializeDatabase(db);
                while (isDbCreated) { }
            });
        }

        private static ServiceProvider BuildServiceProvider(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<HospitalDbContext>));
            services.Remove(descriptor);

            services.AddDbContext<HospitalDbContext>(opt => opt.UseNpgsql(CreateConnectionStringForTest()).UseLazyLoadingProxies());
            return services.BuildServiceProvider();
        }

        private static string CreateConnectionStringForTest()
        {
            return "Host=localhost;Database=HospitalTestDb;Username=postgres;Password=root;";
        }

            private static void InitializeDatabase(HospitalDbContext context)
        {
            if (isDbCreated) return;
            isDbCreated = true;

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Admins\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Doctors\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Patients\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Users\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Appointments\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Blogs\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Directions\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"InternalDatas\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Notifications\" RESTART IDENTITY CASCADE;");
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE \"Reports\" RESTART IDENTITY CASCADE;");


            

            Doctor doctor1 = new Doctor(new Guid("e5213e5b-66d3-4f34-8e5c-2087c19f61ab"), "Test Doctor", "Test Doctor",
                 "Test Number", Specialization.Opsta_praksa);
            Doctor doctor2 = new Doctor(new Guid("60427775-a4e7-43a6-9f54-afce9688adcf"), "Test Doctor", "Test Doctor",
                "Test Number", Specialization.Kardiolog);

            context.Doctors.Add(doctor1);
            context.Doctors.Add(doctor2);

            Admin admin = new Admin(new Guid("3c4492f1-6ba4-44e8-ad0f-d61fc2e5dff6"), "Test Admin", "Test Admin", "010101");
            context.Admins.Add(admin);

            Patient patient1 = new Patient(new Guid("21e0b73f-df84-4fcb-93c1-029395181800"), "Test Patient", "Test Patient", "Test number", Gender.Female);
            Patient patient2 = new Patient(new Guid("0f888ab6-f62d-4bbe-9382-6b9d651ac210"), "Test Patient", "Test Patient", "Test number", Gender.Female);
            patient1.AppointTheChosenDoctor(doctor1);
            patient2.AppointTheChosenDoctor(doctor1);
            context.Patients.Add(patient1);
            context.Patients.Add(patient2);

            var range1 = new DateRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0).AddDays(1),
                            new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0).AddDays(3)); 

            var range2 = new DateRange(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0).AddDays(55),
                            new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 30, 0).AddDays(60));

            InternalData internalData1 = new InternalData(new Guid("5bbda782-0d29-4425-b207-0aa72fd19339"), patient1, "1234", 5, 2, 5, range1);
            InternalData internalData2 = new InternalData(new Guid("2cc6fd00-bdd6-451e-8e11-8df443b7c2fa"), patient2, "4321", 8, 22, 21, range2);
            context.InternalDatas.Add(internalData1);
            context.InternalDatas.Add(internalData2);

            Appointment appointment1 = new Appointment(new Guid("ffafa2e4-ee6b-4cd4-95f7-7704339ece0f"), doctor1, patient1, range1, Status.Pending);
            Appointment appointment2 = new Appointment(new Guid("13b96e80-c1e2-4675-9a04-bb3d6e4a2610"), doctor2, patient2, range2, Status.Pending);
            context.Appointments.Add(appointment1);
            context.Appointments.Add(appointment2);

            Report report1 = new Report(new Guid("aad444d0-ce5e-4c28-ae71-e6627ed41671"), doctor1, "DIJAGNOZA HAOS I NERVOZA", "VODE", internalData1, patient1, appointment1);
            Report report2 = new Report(new Guid("f6f2824b-e33c-4dfc-8fd4-a3a40780cb2d"), doctor2, "Mjauuuuuuu", "Mjau", internalData2, patient2, appointment2);
            context.Reports.Add(report1);
            context.Reports.Add(report2);

            Direction direction1 = new Direction(new Guid("f5bb1206-8dc0-4d3e-8aac-fecd35886d12"), patient1, Specialization.Kardiolog);
            Direction direction2 = new Direction(new Guid("c6ab8125-6163-4dfc-8961-5b21deeb9e32"), patient2, Specialization.Kardiolog);
            context.Directions.Add(direction1);
            context.Directions.Add(direction2);

            Blog blog1 = new Blog(new Guid("7e5a74a2-2e99-4365-8f70-ae333cabd629"), "Lecite se deco", doctor1, BlogTheme.Health);
            Blog blog2 = new Blog(new Guid("1c5a74a2-2e99-4365-8f70-ae333cabd629"), "Lecite se deco", doctor2, BlogTheme.Medicine);
            context.Blogs.Add(blog1);
            context.Blogs.Add(blog2);

            Notification notification = new Notification(new Guid("fbbca2ea-651c-4f7c-af5a-503207bac03b"), admin, "MJAUUUUUU");
            context.Notifications.Add(notification);

            initUsers(context);

            context.SaveChanges();
            isDbCreated = false;




        }


        private static void initUsers(HospitalDbContext context)
        {
            User patient1 = new User(new Guid("3b4fbc0c-3c7f-4e1a-a1bc-25b961584947"), new Guid("21e0b73f-df84-4fcb-93c1-029395181800"), UserType.Patient, "patient1@gmail.com", "123");
            patient1.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            patient1.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            patient1.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            User patient2 = new User(new Guid("30fe9cb2-9518-460d-be48-7cbd5ba614a4"), new Guid("0f888ab6-f62d-4bbe-9382-6b9d651ac210"), UserType.Patient, "patient2@gmail.com", "123");
            patient2.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            patient2.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));

            context.Users.Add(patient1);
            context.Users.Add(patient2);

            User blocked1 = new User(new Guid("e274f85a-034a-477a-bf8f-5f21467e9caa"), new Guid("22e0b73f-df84-4fcb-93c1-029395181800"), UserType.Patient, "patient3@gmail.com", "123");
            User blocked2 = new User(new Guid("a59197e6-a685-4122-be24-b6a2ae477b9d"), new Guid("23e0b73f-df84-4fcb-93c1-029395181800"), UserType.Patient, "patient4@gmail.com", "123");
            User notBlocked1 = new User(new Guid("c86d1f40-35b6-4a29-aba0-1661e06a422f"), new Guid("24e0b73f-df84-4fcb-93c1-029395181800"), UserType.Patient, "patient5@gmail.com", "123");
            User notBlecked2 = new User(new Guid("4ab3fe26-cdb1-44e8-aadb-70e4cb9ebc40"), new Guid("25e0b73f-df84-4fcb-93c1-029395181800"), UserType.Patient, "patient6@gmail.com", "123");

            blocked1.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            blocked1.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            blocked1.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            blocked1.Block();


            blocked2.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            blocked2.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            blocked2.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            blocked2.Block();

            notBlocked1.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            notBlocked1.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            notBlocked1.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));

            notBlecked2.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            notBlecked2.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));
            notBlecked2.AddSuspiciousActivity(new SuspiciousActivity("cancelation"));


            context.Users.Add(blocked1);
            context.Users.Add(blocked2);
            context.Users.Add(notBlocked1);
            context.Users.Add(notBlecked2);


            User doctor1 = new User(new Guid("36cc0978-e593-4016-b7d2-208632a451ac"), new Guid("e5213e5b-66d3-4f34-8e5c-2087c19f61ab"), UserType.Doctor, "doctor1@gmail.com", "123");
            User doctor2 = new User(new Guid("6deafaf1-1e44-4491-aede-540806bed667"), new Guid("60427775-a4e7-43a6-9f54-afce9688adcf"), UserType.Doctor, "doctor2@gmail.com", "123");
            context.Users.Add(doctor1);
            context.Users.Add(doctor2);

            User admin = new User(new Guid("7c8767d2-2241-473e-820b-ac1abd384b69"), new Guid("3c4492f1-6ba4-44e8-ad0f-d61fc2e5dff6"), UserType.Admin, "admin@gmail.com", "123");
            context.Users.Add(admin);

        }



    }
}
