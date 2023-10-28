using Appointment.Infrastructure.Database.Context;
using KarizmaClinicManagementSystem.Framework.Outbox;

namespace Appointment.Infrastructure.Outbox;

public class OutboxAccessor : IOutbox
{
    private readonly AppointmentDbContext dbContext;

    //internal OutboxAccessor(AppointmentDbContext dbContext)
    //{
    //    this.dbContext = dbContext;
    //}

    public void Add(OutboxMessage message)
    {
        dbContext.OutboxMessages.Add(message);
    }

    public Task Save()
    {
        return Task.CompletedTask; 
        // Save is done automatically using EF Core Change Tracking mechanism during SaveChanges.
    }
}