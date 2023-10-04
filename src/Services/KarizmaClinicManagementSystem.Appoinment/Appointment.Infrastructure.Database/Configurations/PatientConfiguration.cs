using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.AggregatesModel.DoctorTypeAggregate;
using Appointment.Domain.Core.AggregatesModel.PatientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Database.Configurations;

public sealed class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.ToTable("Patients", "Appointment");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).HasConversion(v => v.Value, v => new PatientId(v));
        builder.Property(x => x.Email).IsRequired();
        builder.Property(x => x.Mobile).IsRequired();
        builder.OwnsOne(x => x.Info, i =>
        {
            i.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            i.Property(x => x.LastName).IsRequired().HasMaxLength(50);
            i.Property(x => x.NationalCode).IsRequired().HasMaxLength(10);
        });
        builder.HasMany(d => d.Appointments)
            .WithOne()
            .HasForeignKey(a => a.PatientId);
    }
}
