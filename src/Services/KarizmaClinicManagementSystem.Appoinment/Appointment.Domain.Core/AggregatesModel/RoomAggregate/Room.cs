
using KarizmaClinicManagementSystem.Framework.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.AggregatesModel.RoomAggregate;

public class Room : AggregateRoot<RoomId>
{
    public string Title { get; set; }
    public Room()
    {
        
    }
}
