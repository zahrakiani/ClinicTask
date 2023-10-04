using Appointment.Application.Validation;
using Appointment.Domain.Core.Interfaces.IService.DoctorService;
using Appointment.Domain.Core.Interfaces.IService.PatientService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.CQRS.Appointment.Commands.CreateAppointmentWithSpecifiedTime;

public class CreateAppointmentWithSpecificTimeRequestValidator : 
    CustomValidator<CreateAppointmentWithSpecificTimeRequest>
{

    public CreateAppointmentWithSpecificTimeRequestValidator(ICheckDoctorExist checkDoctorExist,
        ICheckPatientExist checkPatientExist)
    {
        RuleFor(c => c.PatientId)
            .NotEmpty()
            .NotNull()
            .Must(x=>checkPatientExist.IsValid(x))
            .WithMessage((_, a) => "The patient not exist"); 

        RuleFor(c => c.DoctorId)
            .NotEmpty()
            .NotNull()
            .Must(x=> checkDoctorExist.IsValid(x))
            .WithMessage("The doctor not exist");

        RuleFor(x => x.Date)
               .NotEmpty()
               .NotNull()
               .Must(x => x >= DateOnly.FromDateTime(DateTime.Now))
               .WithMessage("The date can not be smaller than now"); 

        RuleFor(x => x.StartTime)
               .NotEmpty()
               .NotNull()
               .Must(x => x > TimeOnly.FromDateTime(DateTime.Now))
               .When(x=>x.Date == DateOnly.FromDateTime(DateTime.Now))
               .WithMessage("The start time can not be smaller than now");
    }
}
