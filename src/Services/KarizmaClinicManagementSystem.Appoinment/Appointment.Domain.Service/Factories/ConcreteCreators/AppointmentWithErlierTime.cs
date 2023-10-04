using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Shared.Validation;
using Appointment.Domain.Service.Factories.CreatorInterface;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Service.Factories.ConcreteCreators;

public class AppointmentWithErlierTime : IAppointment
{
    private IDoctorRepository doctorRepository;
    private IDoctorTypeRepository doctorTypeRepository;

    public AppointmentWithErlierTime(IDoctorRepository doctorRepository)
    {
        this.doctorRepository = doctorRepository;
    }

    public AppointmentWithErlierTime(IDoctorRepository doctorRepository,
        IDoctorTypeRepository doctorTypeRepository) : this(doctorRepository)
    {
        this.doctorTypeRepository = doctorTypeRepository;
    }
    public Task<Core.AggregatesModel.AppointmentAggregate.Appointment> Create(DateTime startTime, 
        Guid doctorId, 
        Guid patientId,
        int durationTime)
    {
        //DateTime doctorErlierTime = await GetErlierTimeAsync(doctorId);
        throw new NotImplementedException();
    }

    private async Task<DateTime> GetErlierTimeAsync(Guid doctorId)
    {
        var doctor = doctorRepository.GetById(doctorId);
        CommonValidation.CheckNotNull(doctor, ErrorCode.IsNull(nameof(doctor)));
        var doctorType = doctorTypeRepository.GetById(doctor.DoctorTypeId.Value);
        var doctorSchedule = doctor.WeeklySchedule.Where(x=>x.Date > DateTime.Now).OrderBy(x=>x.Date).ThenBy(x=>x.StartTime);


        throw new NotImplementedException();
    }
}
