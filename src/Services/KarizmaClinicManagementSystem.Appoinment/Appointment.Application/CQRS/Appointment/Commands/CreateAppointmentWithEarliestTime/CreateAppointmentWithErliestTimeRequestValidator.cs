using Appointment.Application.Validation;
using Appointment.Domain.Core.Interfaces.IService.DoctorService;
using Appointment.Domain.Core.Interfaces.IService.PatientService;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.CQRS.Appointment.Commands.CreateAppointmentWithEarliestTime;

public class CreateAppointmentWithSpecificTimeAndDurationRequestValidator : 
    CustomValidator<AppointmentWithSpecificTimeAndDurationRequest>
{
	public CreateAppointmentWithSpecificTimeAndDurationRequestValidator(ICheckDoctorExist checkDoctorExist,
        ICheckPatientExist checkPatientExist)
    {
        RuleFor(c => c.PatientId)
            .NotEmpty()
            .NotNull()
            .Must(x => checkPatientExist.IsValid(x))
            .WithMessage((_, a) => "The patient not exist");

        RuleFor(c => c.DoctorId)
            .NotEmpty()
            .NotNull()
            .Must(x => checkDoctorExist.IsValid(x))
            .WithMessage("The doctor not exist");

        RuleFor(x => x.DurationMinutes)
               .NotEmpty()
               .NotNull(); 

    }

}

