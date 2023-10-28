﻿using Appointment.Application.Contracts;

namespace Appointment.Application.Configuration.Commands;

public abstract class QueryBase<TResult> : IQuery<TResult>
{
    public Guid Id { get; }

    protected QueryBase()
    {
        this.Id = Guid.NewGuid();
    }

    protected QueryBase(Guid id)
    {
        this.Id = id;
    }
}