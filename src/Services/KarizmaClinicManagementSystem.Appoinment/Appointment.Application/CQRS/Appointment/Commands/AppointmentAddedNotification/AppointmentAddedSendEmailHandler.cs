
using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Events;
using Appointment.Domain.Core.Interfaces.IRepository;
using KarizmaClinicManagementSystem.Framework.Notifications.Email;
using MediatR;


namespace Appointment.Application.CQRS.Appointment.Commands.SendAppointmentAddedEmail;

 public class AppointmentAddedSendEmailHandler : INotificationHandler<AddAppointmentSendNotificationEvent>
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

    public async Task Handle(AddAppointmentSendNotificationEvent notification, CancellationToken cancellationToken)
    {
        // A more correct way: using the queue system

        var doctor = await doctorRepository.GetByIdAsync(notification.DoctorId);

        var patient = await patientRepository.GetByIdAsync(notification.PatientId);

        var appointment = await appointmentRepository.GetByIdAsync(notification.AppointmentId);

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
