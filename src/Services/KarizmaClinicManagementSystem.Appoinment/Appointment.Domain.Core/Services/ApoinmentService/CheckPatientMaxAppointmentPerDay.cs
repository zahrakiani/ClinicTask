using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Services.ApoinmentService;

public class CheckPatientMaxAppointmentPerDay : ICheckPatientMaxAppointmentPerDay
{
    private readonly IPatientRepository patientRepository;
    int maxPatientAppointmentPerDay = 2; // Move to appConfig Or get from db
    public CheckPatientMaxAppointmentPerDay(IPatientRepository patientRepository)
    {
        this.patientRepository = patientRepository;
    }
    public bool IsValid(Guid patientId, DateTime startDate)
    {
        var appointments = patientRepository.GetAppointmentsOfPatientByDate(patientId,DateOnly.FromDateTime(startDate));
        return appointments.Count() < maxPatientAppointmentPerDay;
    }
}
