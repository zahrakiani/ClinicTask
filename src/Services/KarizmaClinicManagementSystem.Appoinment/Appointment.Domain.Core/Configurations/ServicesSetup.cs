using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Interfaces.IService.DoctorService;
using Appointment.Domain.Core.Interfaces.IService.PatientService;
using Appointment.Domain.Core.Interfaces;
using Appointment.Domain.Core.Services.ApoinmentService;
using Appointment.Domain.Core.Services.DoctorService;
using Appointment.Domain.Core.Services.PatientService;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Configurations;

public static class DomainServicesSetup
{
    public static void AddServicesSetup(this IServiceCollection services)
    {

        //Appoitment
        services.AddScoped<ICheckPatientAppointmentOverlap, CheckPatientAppointmentOverlap>();
        services.AddScoped<ICheckPatientMaxAppointmentPerDay, CheckPatientMaxAppointmentPerDay>();
        services.AddScoped<ICheckClinicWorkingTime, CheckClinicWorkingTime>();
        services.AddScoped<ICheckDoctorAppointmentOverlapLimit, CheckDoctorAppointmentOverlapLimit>();
        services.AddScoped<ICheckDoctorWorkingTime, CheckDoctorWorkingTime>();

        //Doctor 
        services.AddScoped<ICheckDoctorDailyScheduleIsInClinicWorkingHours, CheckDoctorDailyScheduleIsInClinicWorkingHours>();
        services.AddScoped<ICheckDoctorExist, CheckDoctorExist>();

        //Patient
        services.AddScoped<ICheckPatientExist, CheckPatientExist>();
    }
}
