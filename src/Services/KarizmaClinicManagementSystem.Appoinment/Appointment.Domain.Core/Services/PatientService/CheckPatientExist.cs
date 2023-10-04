using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces.IService.PatientService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Services.PatientService;

public class CheckPatientExist : ICheckPatientExist
{
    private readonly IPatientRepository patientRepository;

    public CheckPatientExist(IPatientRepository patientRepository)
    {
        this.patientRepository = patientRepository;
    }

    public bool IsValid(Guid patientId)
    {
        var doctor =  patientRepository.GetById(patientId);
        if (doctor is null)
            return false;
        return true;
    }
}
