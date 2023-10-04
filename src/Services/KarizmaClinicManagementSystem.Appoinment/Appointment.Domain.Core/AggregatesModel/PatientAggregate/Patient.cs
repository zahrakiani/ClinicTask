using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using Appointment.Domain.Core.AggregatesModel.PatientAggregate.ValueObject;
using KarizmaClinicManagementSystem.Framework.Abstracts;
using KarizmaClinicManagementSystem.Framework.BaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.AggregatesModel.PatientAggregate;

public class Patient : AggregateRoot<PatientId>
{
    public PersonalInfo Info { get; private set; }
    public string Email { get; private set; }
    public string Mobile { get; private set; }

    private readonly List<AppointmentAggregate.Appointment> appointments = new List<AppointmentAggregate.Appointment>();
    public IReadOnlyList<AppointmentAggregate.Appointment> Appointments => appointments;

    public Patient()
    {
        
    }

    public Patient(PersonalInfo info, string email, string mobile, List<AppointmentAggregate.Appointment> appointments)
    {
        Info = info;
        Email = email;
        Mobile = mobile;
        this.appointments = appointments;
    }
}
