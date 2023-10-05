using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.ValueObjects;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Services.ApoinmentService;
using Appointment.Domain.Core.Shared.Validation;
using KarizmaClinicManagementSystem.Framework.BaseModels;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;

namespace Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Rules;

public class AppointmentMustBeInClinicWorkingHoursRule : IBusinessRule
{

    public string Message => ErrorCode.OutsideOfClinicHours.Message;
    public string Code => ErrorCode.OutsideOfClinicHours.Code;

    private readonly AppointmentTime appointmentTime;
    private readonly ICheckClinicWorkingTime checkClinicWorkingTime;
    private readonly ErrorCode errorCode;

    public AppointmentMustBeInClinicWorkingHoursRule(AppointmentTime appointmentTime, 
        IClinicRepository clinicRepository)
    {
        CommonValidation.CheckNotNull(appointmentTime, ErrorCode.IsNull(nameof(appointmentTime)));
        CommonValidation.CheckNotNull(clinicRepository, ErrorCode.IsNull(nameof(clinicRepository)));

        this.appointmentTime = appointmentTime;
        this.checkClinicWorkingTime = new CheckClinicWorkingTime(clinicRepository);
    }


    public bool IsBroken()
    {
        var result = !checkClinicWorkingTime.IsValid(appointmentTime.StartTime,appointmentTime.EndTime);
        return result;
    }

}
