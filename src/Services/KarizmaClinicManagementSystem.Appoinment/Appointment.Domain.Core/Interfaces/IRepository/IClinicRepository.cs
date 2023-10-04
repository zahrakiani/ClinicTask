using Appointment.Domain.Core.AggregatesModel.ClinicAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Interfaces.IRepository;

public interface IClinicRepository
{
    Task AddAsync(Clinic clinic);
    Clinic GetById(ClinicId id);
    Clinic GetMainClinic();
}
