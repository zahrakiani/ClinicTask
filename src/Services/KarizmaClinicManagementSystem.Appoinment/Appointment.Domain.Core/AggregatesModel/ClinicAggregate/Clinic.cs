using KarizmaClinicManagementSystem.Framework.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.AggregatesModel.ClinicAggregate;

public class Clinic : AggregateRoot<ClinicId>
{

    public string Name { get; private set; }
    public string Description { get; private set; }
    public DayOfWeek StartDay { get; private set; }
    public DayOfWeek EndDay { get; private set; }
    public TimeSpan StartTime { get; private set; }
    public TimeSpan EndTime { get; private set; }
    public Clinic()
    {

    }

    private Clinic(ClinicId clinicId, string name, string description, DayOfWeek startDay, DayOfWeek endDay, TimeSpan startTime, TimeSpan endTime)
    {
        Id= clinicId;
        Name = name;
        Description = description;
        StartDay = startDay;
        EndDay = endDay;
        StartTime = startTime;
        EndTime = endTime;
    }

    public static Clinic CreateClinic(string name,
        string description,
        DayOfWeek startDay,
        DayOfWeek endDay,
        TimeSpan startTime,
        TimeSpan endTime)
    {
        var clinicId = new ClinicId(Guid.NewGuid());
        return new Clinic(clinicId, name, description,startDay,endDay,startTime,endTime);
    }
}
