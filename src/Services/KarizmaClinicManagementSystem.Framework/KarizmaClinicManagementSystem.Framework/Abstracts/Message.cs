using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarizmaClinicManagementSystem.Framework.Abstracts;

public abstract record class Message
{
    public string MessageType { get; init; }
    public Guid AggregateId { get; init; }

    protected Message()
    {
        MessageType = GetType().FullName;
    }
}
