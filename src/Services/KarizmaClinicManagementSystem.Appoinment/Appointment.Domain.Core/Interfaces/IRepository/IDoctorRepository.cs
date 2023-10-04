using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;

namespace Appointment.Domain.Core.Interfaces.IRepository;

public interface IDoctorRepository
{
    Doctor GetById(Guid id);
    List<AggregatesModel.AppointmentAggregate.Appointment> GetAppointmentListByDoctorId(Guid doctorId);
    Task<List<AggregatesModel.AppointmentAggregate.Appointment>> GetAppointmentListByDoctorIdAsync(Guid doctorId);
    List<AggregatesModel.AppointmentAggregate.Appointment> GetAppointmentListByDoctorIdAndTime(Guid doctorId, DateOnly date);
}
