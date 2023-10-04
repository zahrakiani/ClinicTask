using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Shared.Utility;
using Appointment.Domain.Core.Shared.Validation;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Service.Services.ApoinmentService;

public class CheckDoctorAppointmentOverlapLimit : ICheckDoctorAppointmentOverlapLimit
{
    private readonly IDoctorRepository doctorRepository;
    private readonly IDoctorTypeRepository doctorTypeRepository;

    public CheckDoctorAppointmentOverlapLimit(IDoctorRepository doctorRepository, 
        IDoctorTypeRepository doctorTypeRepository)
    {
        this.doctorRepository = doctorRepository;
        this.doctorTypeRepository = doctorTypeRepository;
    }
    public bool IsValid(Guid doctorId, DateTime startDate, DateTime endDate)
    {
        var doctor = doctorRepository.GetById(doctorId);
        CommonValidation.CheckNotNull(doctor, ErrorCode.IsNull(nameof(doctor)));
        var Appointments = doctorRepository.GetAppointmentListByDoctorIdAndTimeAsync(doctorId, DateOnly.FromDateTime(startDate));
        if (Appointments is null) return true;
        var doctorType = doctorTypeRepository.GetById(doctor.DoctorTypeId.Value);
        if (Appointments.Result.Count() <= doctorType.MaxOverlap) return true;
        var result = CheckOverlapLimit(Appointments.Result, doctorType.MaxOverlap, startDate, endDate);
        return result;
    }

    private bool CheckOverlapLimit(List<Core.AggregatesModel.AppointmentAggregate.Appointment> appointments, 
        int maxOverlap, DateTime startDate, DateTime endDate)
    {
        var overlap = 0;
        foreach (var appointment in appointments)
        {
            if (appointment.AppointmentTime.CheckOverlapTime(startDate, endDate)) 
                overlap++; 
            if(overlap > maxOverlap) return true;
        }
        return false;
    }
}
