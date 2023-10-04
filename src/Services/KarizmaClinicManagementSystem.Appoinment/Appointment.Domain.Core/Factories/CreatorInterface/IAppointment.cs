using AppointmentEntity = Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Appointment;

namespace Appointment.Domain.Core.Factories.CreatorInterface;

public interface IAppointment
{
    Task<AppointmentEntity> Create();
}
