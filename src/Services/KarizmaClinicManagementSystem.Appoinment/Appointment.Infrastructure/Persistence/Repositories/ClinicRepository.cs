using Appointment.Domain.Core.AggregatesModel.ClinicAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Infrastructure.Database.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Infrastructure.Persistence.Repositories;

public class ClinicRepository : IClinicRepository
{
    private readonly AppointmentDbContext dbContext;
    public ClinicRepository(AppointmentDbContext dbContext) => this.dbContext = dbContext;

    public async Task AddAsync(Clinic clinic)
    => await dbContext.AddAsync(clinic);

    public Clinic GetById(ClinicId id)
    => dbContext.Clinics.FirstOrDefault(x => x.Id == id);

    public Clinic GetMainClinic()
    => dbContext.Clinics.FirstOrDefault();
}
