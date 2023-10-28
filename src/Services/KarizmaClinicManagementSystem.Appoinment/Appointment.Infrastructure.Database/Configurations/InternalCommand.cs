using Appointment.Domain.Core.AggregatesModel.PatientAggregate;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Database.Configurations;

public class InternalCommand
{
    public InternalCommand()
    {
        
    }
    public int Id { get; set; }
    public DateTime EnqueueDate { get; set; }
    public string Type { get; set; }
    public string Data { get; set; }
    public DateTime ProcessedDate { get; set; }
    public string Error { get; set; }
    
}

public sealed class InternalCommandConfiguration : IEntityTypeConfiguration<InternalCommand>
{
    public void Configure(EntityTypeBuilder<InternalCommand> builder)
    {
        builder.ToTable("InternalCommands", "Appointment");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.EnqueueDate).IsRequired();
        builder.Property(x => x.Type).IsRequired().HasMaxLength(255);
        builder.Property(x => x.Data).IsRequired();

    }
}