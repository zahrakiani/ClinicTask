using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Service.Services.ApoinmentService;

public static class AppointmentIdService
{
    public static AppointmentId GenerateNewAppointmentId()
    => new AppointmentId(Guid.NewGuid());
    
    public static AppointmentId ConvertToAppointmentId(this Guid guid)
    => new AppointmentId(guid);
    
    public static T ConvertToAppointmentId<T>(this Guid guid) where T : new()
    {
        var yyy = (T)Activator.CreateInstance(typeof(T), guid);
        return yyy;
    }
}
