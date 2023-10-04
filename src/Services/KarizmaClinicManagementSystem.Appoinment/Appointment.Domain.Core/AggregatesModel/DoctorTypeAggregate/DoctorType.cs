using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using KarizmaClinicManagementSystem.Framework.BaseModels;

namespace Appointment.Domain.Core.AggregatesModel.DoctorTypeAggregate;

public class DoctorType : AggregateRoot<DoctorTypeId>
{

    public string Title { get; private set; }
    public string Description { get; private set; }
    public int MaxOverlap { get; private set; }
    public TimeSpan MinDurationAppointmentTime { get; private set; }
    public TimeSpan MaxDurationAppointmentTime { get; private set; }
    public DoctorType()
    {

    }

    public DoctorType(DoctorTypeId id, string title, string description, int maxOverlap, TimeSpan minDuration, TimeSpan maxDuration)
    {
        Id = id;
        Title = title;
        Description = description;
        MaxOverlap = maxOverlap;
        MinDurationAppointmentTime = minDuration;
        MaxDurationAppointmentTime = maxDuration;
    }
    public static DoctorType CreateNew(string title, string description, int maxOverlap, TimeSpan MinDuration, TimeSpan MaxDuration)
    {
        var doctorTypeId = new DoctorTypeId(Guid.NewGuid());
        return new DoctorType(doctorTypeId,title, description, maxOverlap, MinDuration, MaxDuration);
    }
}