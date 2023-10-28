using Appointment.Application.Events;
using Appointment.Infrastructure.Serialization;
using KarizmaClinicManagementSystem.Framework.BaseModels;
using KarizmaClinicManagementSystem.Framework.Outbox;
using MediatR;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using static System.Formats.Asn1.AsnWriter;

namespace Appointment.Infrastructure.DomainEventsDispatching;

public class DomainEventsDispatcher : IDomainEventsDispatcher
{
    private readonly IMediator mediator;
    private readonly IDomainEventsAccessor domainEventsProvider;


    public DomainEventsDispatcher(
        IMediator mediator,
        IDomainEventsAccessor domainEventsProvider)
    {
        this.mediator = mediator;
        this.domainEventsProvider = domainEventsProvider;
    }

    public async Task DispatchEventsAsync()
    {
        var domainEvents = domainEventsProvider.GetAllDomainEvents();

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);

        }

    }
}