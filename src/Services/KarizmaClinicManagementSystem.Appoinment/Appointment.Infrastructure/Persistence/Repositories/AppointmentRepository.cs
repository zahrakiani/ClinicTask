using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Services.ApoinmentService;
using Appointment.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;
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


    public async Task<Domain.Core.AggregatesModel.AppointmentAggregate.Appointment> GetByIdAsync(Guid id)
     => await dbContext.Appointments.FirstOrDefaultAsync(x => x.Id == id.ConvertToAppointmentId());
}
