using Appointment.Domain.Core.AggregatesModel.ClinicAggregate;
using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.AggregatesModel.DoctorTypeAggregate;
using Appointment.Domain.Core.AggregatesModel.PatientAggregate;
using Appointment.Infrastructure.Database.Configurations;
using KarizmaClinicManagementSystem.Framework.Outbox;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Infrastructure.Database.Context;

public class AppointmentDbContext : DbContext
{
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Domain.Core.AggregatesModel.AppointmentAggregate.Appointment> Appointments { get; set; }
    public DbSet<DoctorType> DoctorTypes { get; set; }
    public DbSet<Clinic> Clinics { get; set; }
    public DbSet<InternalCommand> InternalCommands { get; set; }
    public DbSet<OutboxMessage> OutboxMessages { get; set; }

    public AppointmentDbContext(DbContextOptions<AppointmentDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppointmentDbContext).Assembly);
        DataSeedingExecute(modelBuilder);
        
    }

    private void DataSeedingExecute(ModelBuilder modelBuilder)
    {
        //Seeding Data
        modelBuilder.Entity<Clinic>()
            .HasData(Clinic.CreateClinic("KarizmaClinic",
            "KarizmaClinic is a test project on related to Karizma company, which was implemented by Zahra Kiani.",
            DayOfWeek.Saturday,
            DayOfWeek.Wednesday,
            new TimeSpan(9, 0, 0),
            new TimeSpan(18, 0, 0)
        ));

        //modelBuilder.Entity<DoctorType>()
        //    .HasData(
        //    DoctorType.CreateNew("General", "General Doctor", 2, new TimeSpan(0, 5, 0), new TimeSpan(0, 15, 0)),
        //    DoctorType.CreateNew("Specialist", "Specialist Doctor", 3, new TimeSpan(0, 10, 0), new TimeSpan(0, 30, 0)));

        //modelBuilder.Entity<Doctor>()
        //    .HasData(
        //    Doctor.CreateNew("Neurologists", 
        //    "Sara", 
        //    "Tehrani", 
        //    new DoctorTypeId(new Guid("3be242d6-6b44-41a4-ac50-5f35f39c71a2")),
        //    "Tehrani@clinic.com",
        //    "09121211212"),
        //    Doctor.CreateNew("Dermatologist", 
        //    "Hamid", 
        //    "Ahmadi", 
        //    new DoctorTypeId(new Guid("fb92b7ef-4b57-49bb-87b4-86ac3dba0e70")),
        //    "Ahmadi@clinic.com",
        //    "09121231313"));

        modelBuilder.Entity<DoctorType>().HasData(
            new
            {
                Id = new DoctorTypeId(new Guid("3be242d6-6b44-41a4-ac50-5f35f39c71a2")),
                Title = "Specialist",
                Description = "Specialist Doctor",
                MaxOverlap = 3,
                MaxDurationAppointmentTime = new TimeSpan(0, 0, 30, 0, 0),
                MinDurationAppointmentTime = new TimeSpan(0, 0, 10, 0, 0),
            },
            new
            {
                Id = new DoctorTypeId(new Guid("fb92b7ef-4b57-49bb-87b4-86ac3dba0e70")),
                Title = "General",
                Description = "General Doctor",
                MaxOverlap = 2,
                MaxDurationAppointmentTime = new TimeSpan(0, 0, 15, 0, 0),
                MinDurationAppointmentTime = new TimeSpan(0, 0, 5, 0, 0)
            });

        modelBuilder.Entity<Doctor>().HasData(
            new { Id = new DoctorId(new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0")), DoctorTypeId = new DoctorTypeId(new Guid("3be242d6-6b44-41a4-ac50-5f35f39c71a2")), Email = "Tehrani@clinic.com", Mobile = "09121211212" },
            new { Id = new DoctorId(new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d")), DoctorTypeId = new DoctorTypeId(new Guid("fb92b7ef-4b57-49bb-87b4-86ac3dba0e70")), Email = "Ahmadi@clinic.com", Mobile = "09121231313" });

        modelBuilder.Entity<Doctor>().OwnsOne(p => p.Info).HasData(
            new { DoctorId = new DoctorId(new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0")), Prefix = "Neurologists", FirstName = "Sara", LastName = "Tehrani" },
            new { DoctorId = new DoctorId(new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d")), Prefix = "Dermatologist", FirstName = "Hamid", LastName = "Ahmadi" });

        modelBuilder.Entity<Patient>().HasData(
            new { Id = new PatientId(new Guid("929dd2a4-a952-4400-897d-4e0a683f5a66")), Email = "client1@gmail.com", Mobile = "09124214242" },
            new { Id = new PatientId(new Guid("8fce7d4f-2607-4588-8211-373b21850844")), Email = "client2@yahoo.com", Mobile = "09125235353" });

        modelBuilder.Entity<Patient>().OwnsOne(p => p.Info).HasData(
            new { PatientId = new PatientId(new Guid("929dd2a4-a952-4400-897d-4e0a683f5a66")), NationalCode = "0023456789", FirstName = "Ali", LastName = "Alizade" },
            new { PatientId = new PatientId(new Guid("8fce7d4f-2607-4588-8211-373b21850844")), NationalCode = "1230012300", FirstName = "Mina", LastName = "Amiri" });

        modelBuilder.Entity<Doctor>().OwnsMany(p => p.WeeklySchedule).HasData(
            new { Id = Guid.NewGuid(), DoctorId = new DoctorId(new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0")), Date = DateTime.Now.AddDays(3), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(12, 0, 0) },
            new { Id = Guid.NewGuid(), DoctorId = new DoctorId(new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0")), Date = DateTime.Now.AddDays(4), StartTime = new TimeSpan(14, 0, 0), EndTime = new TimeSpan(18, 0, 0) },
            new { Id = Guid.NewGuid(), DoctorId = new DoctorId(new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0")), Date = DateTime.Now.AddDays(5), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(12, 0, 0) },
            new { Id = Guid.NewGuid(), DoctorId = new DoctorId(new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0")), Date = DateTime.Now.AddDays(6), StartTime = new TimeSpan(14, 0, 0), EndTime = new TimeSpan(18, 0, 0) },
            new { Id = Guid.NewGuid(), DoctorId = new DoctorId(new Guid("6249f3e0-b7f2-411c-ad77-71de3c2417f0")), Date = DateTime.Now.AddDays(7), StartTime = new TimeSpan(9, 0, 0), EndTime = new TimeSpan(12, 0, 0) },
            new { Id = Guid.NewGuid(), DoctorId = new DoctorId(new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d")), Date = DateTime.Now.AddDays(3), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(14, 0, 0) },
            new { Id = Guid.NewGuid(), DoctorId = new DoctorId(new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d")), Date = DateTime.Now.AddDays(4), StartTime = new TimeSpan(14, 0, 0), EndTime = new TimeSpan(18, 0, 0) },
            new { Id = Guid.NewGuid(), DoctorId = new DoctorId(new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d")), Date = DateTime.Now.AddDays(5), StartTime = new TimeSpan(13, 0, 0), EndTime = new TimeSpan(17, 0, 0) },
            new { Id = Guid.NewGuid(), DoctorId = new DoctorId(new Guid("adc6c6a6-49e5-4c81-b168-7bee8f91125d")), Date = DateTime.Now.AddDays(6), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(14, 0, 0) });
    }
}

