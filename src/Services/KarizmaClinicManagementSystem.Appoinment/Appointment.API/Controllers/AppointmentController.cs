using Appointment.Application.CQRS.Appointment.Commands.AppointmentWithSpecificTimeAndDuration;
using Appointment.Application.CQRS.Appointment.Commands.CreateAppointmentWithEarliestTime;
using Appointment.Application.CQRS.Appointment.Commands.CreateAppointmentWithSpecifiedTime;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.API.Controllers;

public class AppointmentController : BaseController
{
    private readonly IMediator mediator;

    public AppointmentController(IMediator mediator)
    {
        this.mediator = mediator;
    }
    [HttpPost]
    public async Task<IActionResult> SetAppointment([FromForm] CreateAppointmentWithSpecificTimeAndDurationRequest createAppointmentWithSpecific)
    {
        try
        {
            var result = await mediator.Send(createAppointmentWithSpecific);
            return Ok(result);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }
    [HttpPost]
    public async Task<IActionResult> SetAppointmentWithSpecificTime([FromForm] CreateAppointmentWithSpecificTimeRequest createAppointmentWithTime)
    {
        try
        {
            var result = await mediator.Send(createAppointmentWithTime);
            return Ok(result);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }

    [HttpPost]
    public async Task<IActionResult> SetEarliestAppointment([FromForm] AppointmentWithSpecificTimeAndDurationRequest createAppointmentWithErliest)
    {
        try
        {
            var result = await mediator.Send(createAppointmentWithErliest);
            return Ok(result);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }

    }

}
