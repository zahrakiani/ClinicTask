using Appointment.Domain.Core.Interfaces;
using Appointment.Infrastructure.Database.Context;
using Appointment.Infrastructure.DomainEventsDispatching;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppointmentDbContext AppointmentDbContext;
        private readonly IDomainEventsDispatcher domainEventsDispatcher;

        public UnitOfWork(AppointmentDbContext AppointmentDbContext,IDomainEventsDispatcher domainEventsDispatcher)
        {
            this.AppointmentDbContext = AppointmentDbContext;
            this.domainEventsDispatcher = domainEventsDispatcher;
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {

            var result = await AppointmentDbContext.SaveChangesAsync(cancellationToken);

            await domainEventsDispatcher.DispatchEventsAsync();

            Dispose();

            return result;
        }

        public void Dispose()
        {
            AppointmentDbContext.Dispose();
        }
    }
}
