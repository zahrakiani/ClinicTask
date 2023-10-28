using Appointment.Application.Configuration.Commands;
using Appointment.Domain.Core.Interfaces.IRepository;
using ClinicManagementSystem.Framework.Abstracts;
using ClinicManagementSystem.Framework.Notifications.Email;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Application.CQRS.Appointment.Commands.AppointmentAddedNotification;

public class SendApointmentAddedEmailCommandHandler : ICommandHandler<SendApointmentAddedEmailCommand>
{
    //private readonly ISqlConnectionFactory sqlConnectionFactory;
    private readonly IEmailSender emailSender;
    private readonly IDoctorRepository doctorRepository;
    private readonly IPatientRepository patientRepository;
    private readonly IAppointmentRepository appointmentRepository;

    public SendApointmentAddedEmailCommandHandler(/*ISqlConnectionFactory sqlConnectionFactory, */
        IEmailSender emailSender,
        IDoctorRepository doctorRepository,
        IPatientRepository patientRepository,
        IAppointmentRepository appointmentRepository)
    {
        //this.sqlConnectionFactory = sqlConnectionFactory;
        this.emailSender = emailSender;
        this.doctorRepository = doctorRepository;
        this.patientRepository = patientRepository;
        this.appointmentRepository = appointmentRepository;
    }
    public async Task<Unit> Handle(SendApointmentAddedEmailCommand request, CancellationToken cancellationToken)
    {
        var doctor = await doctorRepository.GetByIdAsync(request.DoctorId);

        var patient = await patientRepository.GetByIdAsync(request.PatientId);

        var appointment = await appointmentRepository.GetByIdAsync(request.AppointmentId);

        var email = new EmailMessage(
            patient.Email,
            $"Book a new appointment",
            $"Start Date : {appointment.AppointmentTime.StartTime}," +
            $"Duration : {appointment.AppointmentTime.DurationTime}, " +
            $"DoctorName :{doctor.Info.ToString} , " +
            $"PatientName : {patient.Info.ToString()} ");

        emailSender.SendEmail(email);

        return Unit.Value;
    }

    Task IRequestHandler<SendApointmentAddedEmailCommand>.Handle(SendApointmentAddedEmailCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
