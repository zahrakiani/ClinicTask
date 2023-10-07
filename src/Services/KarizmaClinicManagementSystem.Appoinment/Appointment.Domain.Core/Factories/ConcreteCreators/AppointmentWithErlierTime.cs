using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Shared.Validation;
using Appointment.Domain.Core.Factories.CreatorInterface;
using KarizmaClinicManagementSystem.Framework.ExceptionRules;
using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using AppointmentEntity = Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Appointment;
using System.Collections.ObjectModel;
using Appointment.Domain.Core.Services.ApoinmentService;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Core.Services.DoctorService;
using Appointment.Domain.Core.Services.PatientService;

namespace Appointment.Domain.Core.Factories.ConcreteCreators;

public class AppointmentWithErlierTime : IAppointment
{
    private readonly IDoctorRepository doctorRepository;
    private readonly IDoctorTypeRepository doctorTypeRepository;
    private readonly IClinicRepository clinicRepository;
    private readonly IPatientRepository patientRepository;
    private readonly IAppointmentRepository appointmentRepository;
    private readonly Guid doctorId;
    private readonly Guid patientId;
    private readonly int durationTime;
    private readonly ICheckPatientAppointmentOverlap checkPatientAppointmentOverlap;
    private readonly ICheckPatientMaxAppointmentPerDay checkPatientMaxAppointmentPerDay;


    public AppointmentWithErlierTime(IDoctorRepository doctorRepository,
        IDoctorTypeRepository doctorTypeRepository,
        IClinicRepository clinicRepository,
        IPatientRepository patientRepository,
        IAppointmentRepository appointmentRepository,
        Guid doctorId,
        Guid patientId,
        int durationTime)
    {
        this.doctorRepository = doctorRepository;
        this.doctorTypeRepository = doctorTypeRepository;
        this.clinicRepository = clinicRepository;
        this.patientRepository = patientRepository;
        this.appointmentRepository = appointmentRepository;
        this.doctorId = doctorId;
        this.patientId = patientId;
        this.durationTime = durationTime;
        this.checkPatientAppointmentOverlap = new CheckPatientAppointmentOverlap(patientRepository);
        this.checkPatientMaxAppointmentPerDay = new CheckPatientMaxAppointmentPerDay(patientRepository);

    }


    public async Task<AppointmentEntity> Create()
    {
        DateTime doctorErlierTime = await GetErlierTimeAsync(doctorId, patientId, TimeSpan.FromMinutes(durationTime));
        AppointmentEntity appointment = AppointmentEntity.CreateNew(doctorId.ConvertToDoctorId(),
            patientId.ConvertToPatientId(),
            doctorErlierTime,
            TimeSpan.FromMinutes(durationTime),
            clinicRepository,
            doctorRepository,
            doctorTypeRepository,
            patientRepository,
            appointmentRepository);

        return appointment;
    }

    private async Task<DateTime> GetErlierTimeAsync(Guid doctorId, Guid patientId, TimeSpan durationTime)
    {
        var doctor = doctorRepository.GetById(doctorId);
        CommonValidation.CheckNotNull(doctor, ErrorCode.IsNull(nameof(doctor)));

        var doctorType = doctorTypeRepository.GetById(doctor.DoctorTypeId.Value);

        var doctorAvailableSchedule = doctor.WeeklySchedule.Where(x => x.Date > DateTime.Now)
            .OrderBy(x => x.Date).ThenBy(x => x.StartTime).ToList();

        foreach (var daily in doctorAvailableSchedule)
        {
            if (!checkPatientMaxAppointmentPerDay.IsValid(patientId, daily.Date))
                break;

            DateOnly dateOnlyDaily = DateOnly.FromDateTime(daily.Date);
            DateTime startDailyTime = GetStartTime(dateOnlyDaily, daily.StartTime);
            DateTime endDailyTime = GetDateTime(dateOnlyDaily, daily.EndTime);

            var doctorAppointments = doctorRepository.GetAppointmentListByDoctorIdAndTime(doctorId, dateOnlyDaily)
                .OrderBy(x => x.AppointmentTime.StartTime).ToList();

            // if there is not any reserved time , return first time on the day of doctor
            if (!doctorAppointments.Any()) return startDailyTime;


            TimeSpan sartIndexTime = daily.StartTime < DateTime.Now.TimeOfDay? DateTime.Now.AddMinutes(2).TimeOfDay : daily.StartTime;

            foreach (var appointment in doctorAppointments)
            {
                var firstTimeAfterEndTime = appointment.AppointmentTime.EndTime.AddMinutes(1).TimeOfDay;
                if (sartIndexTime + durationTime <= daily.EndTime)
                {
                    if (sartIndexTime != appointment.AppointmentTime.StartTime.TimeOfDay)
                    {
                        var availAppoinmentRange = new AppoinmentRange
                        {
                            StartTime = sartIndexTime,
                            EndTime = appointment.AppointmentTime.StartTime.TimeOfDay,
                            Duration = (appointment.AppointmentTime.StartTime.TimeOfDay) - (daily.StartTime)
                        };

                        if (availAppoinmentRange.Duration >= durationTime)
                        {
                            var checkPatientOverlap = checkPatientAppointmentOverlap.IsValid(patientId,
                                GetDateTime(dateOnlyDaily, availAppoinmentRange.StartTime),
                                GetDateTime(dateOnlyDaily, availAppoinmentRange.EndTime));
                            if (checkPatientOverlap)
                            {
                                sartIndexTime = firstTimeAfterEndTime;
                                break;
                            }
                            else
                            {
                                return GetDateTime(dateOnlyDaily, availAppoinmentRange.StartTime);
                            }
                        }
                        sartIndexTime = firstTimeAfterEndTime;
                    }
                    else
                    {
                        sartIndexTime = firstTimeAfterEndTime;
                        break;
                    }

                }                
            }
            return GetDateTime(dateOnlyDaily, sartIndexTime);
        }

        throw new Exception("Unfortunately, the doctor has no free time in the current working week");

    }

    private DateTime GetStartTime(DateOnly dateOnlyDaily, TimeSpan startTime)
    {
        return GetDateTime(dateOnlyDaily, startTime) > DateTime.Now ? GetDateTime(dateOnlyDaily, startTime) :
            GetDateTime(dateOnlyDaily, DateTime.Now.AddMinutes(1).TimeOfDay);
        throw new NotImplementedException();
    }

    private DateTime GetDateTime(DateOnly dateOnly, TimeSpan time)
    {
        return dateOnly.ToDateTime(TimeOnly.FromTimeSpan(time));
    }

    private class AppoinmentRange
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public TimeSpan Duration { get; set; }
    }


}
