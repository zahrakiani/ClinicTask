using MediatR;

namespace KarizmaClinicManagementSystem.Framework.Abstracts;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOn { get; }
}
