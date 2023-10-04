using Appointment.Domain.Core.AggregatesModel.DoctorTypeAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Interfaces.IRepository;

public interface IDoctorTypeRepository
{
    DoctorType GetById(Guid id);
}
