using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.AggregatesModel.PatientAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Interfaces.IRepository;

public interface IPatientRepository
{
    Patient GetById(Guid id);
    Task<Patient> GetByIdAsync(Guid id);
    List<AggregatesModel.AppointmentAggregate.Appointment> GetAppointmentsOfPatientByDate(Guid PatientId, DateOnly date);
}
