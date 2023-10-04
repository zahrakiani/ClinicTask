using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.DoctorService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Service.Services.DoctorService;

public class CheckDoctorExist : ICheckDoctorExist
{
    private readonly IDoctorRepository doctorRepository;

    public CheckDoctorExist(IDoctorRepository doctorRepository)
    {
        this.doctorRepository = doctorRepository;
    }
    public bool IsValid(Guid doctorId)
    {
        var doctor = doctorRepository.GetById(doctorId);
        if (doctor is null) 
            return false;
        return true;
    }
}
