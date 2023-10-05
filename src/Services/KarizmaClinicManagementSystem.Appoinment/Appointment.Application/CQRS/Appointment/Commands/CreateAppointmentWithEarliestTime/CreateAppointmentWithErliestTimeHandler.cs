using Appointment.Application.CQRS.Appointment.Commands.CreateAppointmentWithSpecifiedTime;
using Appointment.Application.Dtos;
using Appointment.Domain.Core.Interfaces.IRepository;
using Appointment.Domain.Core.Interfaces;
using Appointment.Domain.Core.Factories.CreatorInterface;
using Appointment.Domain.Core.Factories.Factory;
using FluentValidation;
using MediatR;
using AppointmentEntity = Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Appointment;
using Appointment.Application.Mappers;
using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
using Appointment.Domain.Core.Factories.Decorateor;

namespace Appointment.Application.CQRS.Appointment.Commands.CreateAppointmentWithEarliestTime;

public class AppointmentWithSpecificTimeAndDurationHandler : IRequestHandler<
    AppointmentWithSpecificTimeAndDurationRequest,
    CreatedAppointmentDto>
{
    private readonly IValidator<AppointmentWithSpecificTimeAndDurationRequest> validator;
    private readonly IAppointmentRepository appointmentRepository;
    private readonly IDoctorRepository doctorRepository;
    private readonly IDoctorTypeRepository doctorTypeRepository;
    private readonly IClinicRepository clinicRepository;
    private readonly IPatientRepository patientRepository;
    private readonly IUnitOfWork unitOfWork;

    public AppointmentWithSpecificTimeAndDurationHandler(IValidator<AppointmentWithSpecificTimeAndDurationRequest> validator,
        IAppointmentRepository appointmentRepository,
        IDoctorRepository doctorRepository,
        IDoctorTypeRepository doctorTypeRepository,
        IClinicRepository clinicRepository,
        IPatientRepository patientRepository,
        IUnitOfWork unitOfWork)
    {
        this.validator = validator;
        this.appointmentRepository = appointmentRepository;
        this.doctorRepository = doctorRepository;
        this.doctorTypeRepository = doctorTypeRepository;
        this.clinicRepository = clinicRepository;
        this.patientRepository = patientRepository;
        this.unitOfWork = unitOfWork;
    }
    public async Task<CreatedAppointmentDto> Handle(AppointmentWithSpecificTimeAndDurationRequest request, CancellationToken cancellationToken)
    {
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            throw new Exception(String.Join(",", validationResult.Errors.Select(q => q.ErrorMessage).ToArray()));
        }
        var newAppointmentInstance = await CreateNewInstance(request);
        await appointmentRepository.AddAsync(newAppointmentInstance, cancellationToken);
        await unitOfWork.CommitAsync(cancellationToken);

        return newAppointmentInstance.MapToResultDto();
    }
    private async Task<AppointmentEntity> CreateNewInstance(AppointmentWithSpecificTimeAndDurationRequest request)
    {
        var appointmentFactory = new AppointmentWithErlierTimeFactory(doctorRepository, 
            doctorTypeRepository,
            clinicRepository,
            patientRepository,
            appointmentRepository);

        var appointmentWithSpecificTime = appointmentFactory.GetAppointment(request.DoctorId,
            request.PatientId,
            request.DurationMinutes);

        var createAppoinmentWithRoom = new CreateAppoinmentWithRoomDecorator(appointmentWithSpecificTime);
        var appointment = await createAppoinmentWithRoom.Create();
        return appointment;
    }
}
