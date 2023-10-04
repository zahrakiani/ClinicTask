using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
using Appointment.Domain.Service.Factories.ConcreteCreators;
using Appointment.Domain.Service.Factories.CreatorInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Service.Factories.Factory;

public class AppointmentWithSpecificTimeFactory : AppointmentFactory
{
    private readonly IDoctorRepository doctorRepository;
    private readonly IDoctorTypeRepository doctorTypeRepository;

    public AppointmentWithSpecificTimeFactory(IDoctorRepository doctorRepository,
        IDoctorTypeRepository doctorTypeRepository)
    {
        this.doctorRepository = doctorRepository;
        this.doctorTypeRepository = doctorTypeRepository;
    }
    public override IAppointment GetAppointment()
    {
        return new AppointmentWithSpecificTime(doctorRepository,doctorTypeRepository);
    }
}
