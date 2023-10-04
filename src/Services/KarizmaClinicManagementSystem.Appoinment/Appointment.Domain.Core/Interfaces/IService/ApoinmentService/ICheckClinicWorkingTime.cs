namespace Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
public interface ICheckClinicWorkingTime
{
    bool IsValid(DateTime startDate, DateTime endDate);
}


