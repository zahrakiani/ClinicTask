using Appointment.Application.CQRS.Appointment.Commands.AppointmentAddedNotification;
using Appointment.Domain.Core.Interfaces.IRepository;
using KarizmaClinicManagementSystem.Framework.Notifications.Email;
using MediatR;


namespace Appointment.Application.CQRS.Appointment.Commands.SendAppointmentAddedEmail;

 public class AppointmentAddedSendEmailHandler : INotificationHandler<AppointmentAddedSendNotification>
{
    private readonly IAppointmentRepository appointmentRepository;
    private readonly IDoctorRepository doctorRepository;
    private readonly IPatientRepository patientRepository;
    private readonly IEmailSender emailSender;

    public AppointmentAddedSendEmailHandler(IAppointmentRepository appointmentRepository,
        IDoctorRepository doctorRepository,
        IPatientRepository patientRepository,
        IEmailSender emailSender)
    {
        this.appointmentRepository = appointmentRepository;
        this.doctorRepository = doctorRepository;
        this.patientRepository = patientRepository;
        this.emailSender = emailSender;
    }

    public async Task Handle(AppointmentAddedSendNotification notification, CancellationToken cancellationToken)
    {
        // A more correct way: using the queue system

        var doctor = await doctorRepository.GetByIdAsync(notification.DomainEvent.DoctorId);

        var patient = await patientRepository.GetByIdAsync(notification.DomainEvent.PatientId);

        var appointment = await appointmentRepository.GetByIdAsync(notification.DomainEvent.AppointmentId);

        var email = new EmailMessage(
            patient.Email,
            $"Book a new appointment",
            $"Start Date : {appointment.AppointmentTime.StartTime}," +
            $"Duration : {appointment.AppointmentTime.DurationTime}, " +
            $"DoctorName :{doctor.Info.ToString} , " +
            $"PatientName : {patient.Info.ToString()} ");

        emailSender.SendEmail(email);


    }
}
