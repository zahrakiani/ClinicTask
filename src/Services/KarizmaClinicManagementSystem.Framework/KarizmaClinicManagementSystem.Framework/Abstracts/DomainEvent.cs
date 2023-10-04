using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarizmaClinicManagementSystem.Framework.Abstracts;

public abstract record class DomainEvent : Message, IDomainEvent
{
    public Guid Id { get; }

    public DateTime OccurredOn { get; }

    public DomainEvent()
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
    }
}
