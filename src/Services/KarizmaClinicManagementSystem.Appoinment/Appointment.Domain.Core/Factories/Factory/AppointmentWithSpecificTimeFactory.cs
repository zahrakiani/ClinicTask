using Appointment.Domain.Core.Factories.ConcreteCreators;
using Appointment.Domain.Core.Factories.CreatorInterface;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Factories.Factory;

public class AppointmentWithSpecificTimeFactory 
{
    private readonly IDoctorRepository doctorRepository;
    private readonly IDoctorTypeRepository doctorTypeRepository;
    private readonly IClinicRepository clinicRepository;
    private readonly IPatientRepository patientRepository;
    private readonly IAppointmentRepository appointmentRepository;

    public AppointmentWithSpecificTimeFactory(IDoctorRepository doctorRepository,
        IDoctorTypeRepository doctorTypeRepository,
        IClinicRepository clinicRepository,
        IPatientRepository patientRepository,
        IAppointmentRepository appointmentRepository)
    {
        this.doctorRepository = doctorRepository;
        this.doctorTypeRepository = doctorTypeRepository;
        this.clinicRepository = clinicRepository;
        this.patientRepository = patientRepository;
        this.appointmentRepository = appointmentRepository;
    }
    public IAppointment GetAppointment(Guid doctorId,Guid patientId,DateTime startDate)
    {
        return new AppointmentWithSpecificTime(doctorRepository,
            doctorTypeRepository,
            clinicRepository,
            patientRepository,
            appointmentRepository,
            doctorId,
            patientId,
            startDate);
    }

}
