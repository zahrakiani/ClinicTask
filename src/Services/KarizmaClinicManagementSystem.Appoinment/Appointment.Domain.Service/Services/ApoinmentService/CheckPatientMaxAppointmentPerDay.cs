using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Service.Services.ApoinmentService;

public class CheckPatientMaxAppointmentPerDay : ICheckPatientMaxAppointmentPerDay
{
    private readonly IPatientRepository patientRepository;   
    public CheckPatientMaxAppointmentPerDay(IPatientRepository patientRepository)
    {
        this.patientRepository = patientRepository;
    }
    public bool IsValid(Guid patientId, DateTime startDate, int maxPatientAppointmentPerDay)
    {
        var appointments = patientRepository.GetAppointmentsOfPatientByDateAsync(patientId,DateOnly.FromDateTime(startDate));
        return appointments.Result.Count() < maxPatientAppointmentPerDay;
    }
}
