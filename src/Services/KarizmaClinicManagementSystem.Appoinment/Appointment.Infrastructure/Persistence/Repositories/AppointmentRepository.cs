using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Persistence.Repositories;

public class AppointmentRepository : IAppointmentRepository
{
    private readonly AppointmentDbContext dbContext;

    public AppointmentRepository(AppointmentDbContext dbContext) => this.dbContext = dbContext;
    public async Task AddAsync(Domain.Core.AggregatesModel.AppointmentAggregate.Appointment appointment,
        CancellationToken cancellationToken)
        => await dbContext.AddAsync(appointment, cancellationToken);

    public Domain.Core.AggregatesModel.AppointmentAggregate.Appointment GetByIdAsync(AppointmentId id) 
        => dbContext.Appointments.FirstOrDefault(x => x.Id == id);
}
