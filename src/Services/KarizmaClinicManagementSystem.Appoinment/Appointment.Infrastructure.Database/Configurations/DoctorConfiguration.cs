using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.AggregatesModel.DoctorTypeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Database.Configurations;

public sealed class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.ToTable("Doctors", "Appointment");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(v => v.Value, v => new DoctorId(v));
        builder.Property(x => x.DoctorTypeId).HasConversion(v => v.Value, v => new DoctorTypeId(v));
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Mobile).IsRequired();
        builder.OwnsOne(x => x.Info, i =>
        {
            i.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            i.Property(x => x.LastName).IsRequired().HasMaxLength(50);
        });

   
        builder.HasMany(d => d.Appointments)          
            .WithOne()
            .HasForeignKey(x=>x.DoctorId);

        builder.OwnsMany(x => x.WeeklySchedule, a =>
        {
            a.ToTable("DoctorDailySchedules", "Appointment");
            a.WithOwner().HasForeignKey("DoctorId");
            a.Property(x => x.DoctorId).HasConversion(v => v.Value, v => new DoctorId(v));
            a.Property(x=>x.StartTime).IsRequired();
            a.Property(x => x.EndTime).IsRequired();
            a.Property(x => x.Date).IsRequired();
        });
    }
}
