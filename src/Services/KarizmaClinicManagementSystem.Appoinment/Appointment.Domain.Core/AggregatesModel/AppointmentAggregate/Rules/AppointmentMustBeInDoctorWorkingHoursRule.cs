using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.ValueObjects;
using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Services.ApoinmentService;
using Appointment.Domain.Core.Shared.Validation;
using KarizmaClinicManagementSystem.Framework.BaseModels;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;

namespace Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Rules;

public class AppointmentMustBeInDoctorWorkingHoursRule : IBusinessRule
{
    private readonly Guid doctorId;
    private readonly AppointmentTime appointmentTime;
    private readonly ICheckDoctorWorkingTime checkDoctorWorkingTime;

    public string Code => ErrorCode.OutsideOfDoctorHours.Code;
    public string Message => ErrorCode.OutsideOfDoctorHours.Message;

    public AppointmentMustBeInDoctorWorkingHoursRule(Guid doctorId, AppointmentTime appointmentTime, 
        IDoctorRepository doctorRepository)
    {
        CommonValidation.CheckNotNull(appointmentTime, ErrorCode.IsNull(nameof(appointmentTime)));
        CommonValidation.CheckNotNull(doctorRepository, ErrorCode.IsNull(nameof(doctorRepository)));
        this.doctorId = doctorId;
        this.appointmentTime = appointmentTime;
        this.checkDoctorWorkingTime = new CheckDoctorWorkingTime(doctorRepository);
    }

    public void AdjustError(ErrorCode errorCode)
    {
        throw new NotImplementedException();
    }

    public bool IsBroken()
    {
        var result = !checkDoctorWorkingTime.IsValid(doctorId, appointmentTime.StartTime, appointmentTime.EndTime);
        return result;
    }
}
