using Appointment.Domain.Core.Interfaces;
using Appointment.Infrastructure.Database.Context;
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

        public UnitOfWork(AppointmentDbContext AppointmentDbContext)
        {
            this.AppointmentDbContext = AppointmentDbContext;
        }
        public async Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            var result = await AppointmentDbContext.SaveChangesAsync(cancellationToken);
            Dispose();
            return result;
        }

        public void Dispose()
        {
            AppointmentDbContext.Dispose();
        }
    }
}
