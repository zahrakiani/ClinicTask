using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using Appointment.Domain.Core.AggregatesModel.ClinicAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Database.Configurations;

public sealed class ClinicConfiguration : IEntityTypeConfiguration<Clinic>
{
    public void Configure(EntityTypeBuilder<Clinic> builder)
    {
        builder.ToTable("Clinics", "Appointment");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(v => v.Value, v => new ClinicId(v));
        builder.Property(x => x.Name).HasMaxLength(50);
        builder.Property(x => x.StartDay).IsRequired();
        builder.Property(x => x.EndDay).IsRequired();
        builder.Property(x => x.StartTime).IsRequired();
        builder.Property(x => x.EndTime).IsRequired();
    }
}
