﻿using System;
using System.Runtime.InteropServices.ComTypes;
using MediatR;

namespace Appointment.Application.Contracts;

public interface ICommand<out TResult> : IRequest<TResult>
{
    Guid Id { get; }
}

public interface ICommand : IRequest
{
    Guid Id { get; }
}