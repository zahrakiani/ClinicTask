using MediatR;

namespace Appointment.Application.Contracts;

public interface IQuery<out TResult> : IRequest<TResult>
{
}