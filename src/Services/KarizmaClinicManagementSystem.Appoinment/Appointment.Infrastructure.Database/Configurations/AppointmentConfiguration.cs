using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.AggregatesModel.PatientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Database.Configurations;

public sealed class AppointmentConfiguration 
    : IEntityTypeConfiguration<Domain.Core.AggregatesModel.AppointmentAggregate.Appointment>
{
    public void Configure(EntityTypeBuilder<Domain.Core.AggregatesModel.AppointmentAggregate.Appointment> builder)
    {
        builder.ToTable("Appointments", "Appointment");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(v => v.Value, v => new AppointmentId(v));
        builder.Property(x => x.DoctorId).HasConversion(v => v.Value, v => new DoctorId(v));
        builder.Property(x => x.PatientId).HasConversion(v => v.Value, v => new PatientId(v));

        builder.OwnsOne(x => x.AppointmentTime, a=>
        {
            a.Property(x => x.StartTime).IsRequired();
            a.Property(x => x.DurationTime).IsRequired();
        });
    }
}
