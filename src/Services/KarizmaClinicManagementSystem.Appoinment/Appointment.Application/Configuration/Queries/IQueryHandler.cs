using Appointment.Application.Contracts;
using MediatR;

namespace Appointment.Application.Configuration.Commands;

public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}