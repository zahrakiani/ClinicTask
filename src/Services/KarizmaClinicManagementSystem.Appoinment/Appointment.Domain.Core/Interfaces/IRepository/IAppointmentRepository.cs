using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Interfaces.IRepository;

public interface IAppointmentRepository
{
    Task AddAsync(AggregatesModel.AppointmentAggregate.Appointment appointment, CancellationToken cancellationToken);
    Task<AggregatesModel.AppointmentAggregate.Appointment> GetByIdAsync(Guid id);
}
