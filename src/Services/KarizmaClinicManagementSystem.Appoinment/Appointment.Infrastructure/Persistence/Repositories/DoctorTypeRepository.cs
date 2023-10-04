using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.AggregatesModel.DoctorTypeAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Infrastructure.Persistence.Repositories;

public class DoctorTypeRepository : IDoctorTypeRepository
{
    private readonly AppointmentDbContext dbContext;
    public DoctorTypeRepository(AppointmentDbContext dbContext) => this.dbContext = dbContext;
    public DoctorType GetById(Guid id)
    =>  dbContext.DoctorTypes.FirstOrDefault(x => x.Id == DoctorTypeIdIdFormat(id));

    private DoctorTypeId DoctorTypeIdIdFormat(Guid id)
    => new DoctorTypeId(id);    
}