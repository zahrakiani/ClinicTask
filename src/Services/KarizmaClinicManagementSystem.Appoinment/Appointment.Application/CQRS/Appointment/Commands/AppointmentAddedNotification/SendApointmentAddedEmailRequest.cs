using MediatR;

namespace Appointment.Application.CQRS.Appointment.Commands.SendAppointmentAddedEmail
{
    internal class SendApointmentAddedEmailRequest : IRequest
    {
        public Guid ApointmentId { get; }
        public Guid DoctorId { get; }
        public Guid PatientId { get; }

        public SendApointmentAddedEmailRequest(Guid eventId, Guid apointmentId, Guid doctorId, Guid patientId) 
            //: base(eventId)
        {

            this.ApointmentId = apointmentId;
            this.DoctorId = doctorId;
            this.PatientId = patientId;
        }


    }
}