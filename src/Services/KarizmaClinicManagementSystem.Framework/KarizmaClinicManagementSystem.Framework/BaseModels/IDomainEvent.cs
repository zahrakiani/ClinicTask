using System;
using MediatR;

namespace KarizmaClinicManagementSystem.Framework.BaseModels;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOn { get; }
}