using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.AggregatesModel.DoctorTypeAggregate;
using Appointment.Domain.Core.AggregatesModel.PatientAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Services.PatientService;
using Appointment.Infrastructure.Database.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Appointment.Infrastructure.Persistence.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly AppointmentDbContext dbContext;
    public PatientRepository(AppointmentDbContext dbContext) => this.dbContext = dbContext;
    public List<Domain.Core.AggregatesModel.AppointmentAggregate.Appointment> GetAppointmentsOfPatientByDate(Guid PatientId, DateOnly date)
    {
        var id = PatientId.ConvertToPatientId();
        DateTime startDate = date.ToDateTime(new TimeOnly());
        return dbContext.Appointments.Where(x => x.PatientId == id &&
         x.AppointmentTime.StartTime >= startDate && x.AppointmentTime.StartTime <= startDate.AddDays(1)).ToList();
    }
    public Patient GetById(Guid id)
    => dbContext.Patients.FirstOrDefault(x => x.Id == id.ConvertToPatientId());

}
