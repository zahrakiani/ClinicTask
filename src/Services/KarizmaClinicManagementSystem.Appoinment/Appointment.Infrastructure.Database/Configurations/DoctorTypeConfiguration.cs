using Appointment.Domain.Core.AggregatesModel.ClinicAggregate;
using Appointment.Domain.Core.AggregatesModel.DoctorTypeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Database.Configurations;

internal class DoctorTypeConfiguration : IEntityTypeConfiguration<DoctorType>
{
    public void Configure(EntityTypeBuilder<DoctorType> builder)
    {
        builder.ToTable("DoctorTypes", "Appointment");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(v => v.Value, v => new DoctorTypeId(v));
        builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
        builder.Property(x => x.MinDurationAppointmentTime).IsRequired();
        builder.Property(x => x.MaxDurationAppointmentTime).IsRequired();
        builder.Property(x => x.MaxOverlap).IsRequired();
    }
}
