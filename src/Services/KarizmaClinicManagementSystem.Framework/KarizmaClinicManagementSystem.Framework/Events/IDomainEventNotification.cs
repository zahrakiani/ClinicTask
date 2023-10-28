using System;
using MediatR;

namespace KarizmaClinicManagementSystem.Framework.Events;

public interface IDomainEventNotification<out TEventType> : IDomainEventNotification
{
    TEventType DomainEvent { get; }
}

public interface IDomainEventNotification : INotification
{
    Guid Id { get; }
}