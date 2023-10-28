using Appointment.Domain.Core.Factories.CreatorInterface;
using AppointmentEntity = Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Appointment;

namespace Appointment.Domain.Core.Factories.Decorateor;

public class CreateAppoinmentWithRoomDecorator : CreateAppoinmentDecorator
{
    public CreateAppoinmentWithRoomDecorator(IAppointment appointment) : base(appointment)
    {
    }

    public override async Task<AppointmentEntity> Create()
    {
        var appointment = await base.Create();
        var roomname = "Visiting room 2";
        return AppointmentEntity.SetRoom(appointment,
            roomname
            );
    }

}
