//using Appointment.Application.Configuration.Commands;

//namespace Appointment.Application.CQRS.Appointment.Commands.AppointmentAddedNotification
//{
//    public class SendApointmentAddedEmailCommand : InternalCommandBase
//    {
//        public SendApointmentAddedEmailCommand(Guid id, Guid appointmentId, Guid doctorId, Guid patientId)
//            :base(id)
//        {
//            AppointmentId = appointmentId;
//            DoctorId = doctorId;
//            PatientId = patientId;
//        }

//        public Guid AppointmentId { get; }
//        public Guid DoctorId { get; }
//        public Guid PatientId { get; }

//    }
//}