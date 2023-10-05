
using KarizmaClinicManagementSystem.Framework.BaseModels;

namespace Appointment.Domain.Core.AggregatesModel.RoomAggregate;

public class RoomId : StronglyTypedId<RoomId>
{
    public RoomId(Guid value) : base(value)
    {
    }
}
