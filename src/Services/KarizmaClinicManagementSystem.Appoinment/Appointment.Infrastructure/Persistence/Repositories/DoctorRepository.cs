using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.AggregatesModel.PatientAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Services.DoctorService;
using Appointment.Infrastructure.Database.Context;
using Microsoft.EntityFrameworkCore;

namespace Appointment.Infrastructure.Persistence.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly AppointmentDbContext dbContext;
    public DoctorRepository(AppointmentDbContext dbContext) => this.dbContext = dbContext;

    public List<Domain.Core.AggregatesModel.AppointmentAggregate.Appointment> GetAppointmentListByDoctorIdAndTime(Guid doctorId, DateOnly date)
    {
        var appointmentDate = date.ToDateTime(new TimeOnly());
        return dbContext.Appointments.Where(x => x.DoctorId == doctorId.ConvertToDoctorId() &&
        x.AppointmentTime.StartTime >= appointmentDate && x.AppointmentTime.StartTime <= appointmentDate.AddDays(1)).ToList();
    }

    public List<Domain.Core.AggregatesModel.AppointmentAggregate.Appointment> GetAppointmentListByDoctorId(Guid doctorId)
    =>  dbContext.Appointments.Where(x => x.DoctorId == doctorId.ConvertToDoctorId()).ToList();

    public Doctor GetById(Guid id)
    => dbContext.Doctors.FirstOrDefault(x => x.Id == id.ConvertToDoctorId());

    public async Task<List<Domain.Core.AggregatesModel.AppointmentAggregate.Appointment>> GetAppointmentListByDoctorIdAsync(Guid doctorId)
        =>await dbContext.Appointments.Where(x => x.DoctorId == doctorId.ConvertToDoctorId()).ToListAsync();
}
