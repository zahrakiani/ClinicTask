//using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate;
//using Appointment.Domain.Core.AggregatesModel.DoctorAggregate;
//using Appointment.Domain.Core.AggregatesModel.PatientAggregate;
//using Appointment.Domain.Core.Interfaces.IService.ApoinmentService;
//using Moq;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using AppointmentEntity = Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.Appointment;
//namespace Appointment.Domain.UnitTests.Appoinments;

//public class AppoinmentTests
//{

//    private AppointmentId appointmentId = new AppointmentId(appointmentGuid);
//    private DoctorId doctorId = new DoctorId(doctorGuid);
//    private PatientId patientId = new PatientId(patientGuid);
//    private static Guid appointmentGuid = Guid.NewGuid();
//    private static Guid doctorGuid = Guid.NewGuid();
//    private static Guid patientGuid = Guid.NewGuid();
//    private readonly Mock<ICheckClinicWorkingTime> checkClinicWorkingTimeMock;
//    private readonly Mock<ICheckDoctorWorkingTime> checkDoctorWorkingTimeMock;
//    private readonly Mock<ICheckPatientMaxAppointmentPerDay> checkPatientMaxAppointmentPerDayMock;
//    private readonly Mock<ICheckPatientAppointmentOverlap> checkPatientAppointmentOverlapMock;
//    private readonly Mock<ICheckDoctorAppointmentOverlapLimit> checkDoctorAppointmentOverlapLimitMock;


//    public AppoinmentTests()
//    {
//        checkClinicWorkingTimeMock = new Mock<ICheckClinicWorkingTime>();
//        checkClinicWorkingTimeMock.Setup(
//                    x => x.IsValid(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(true);

//        checkDoctorWorkingTimeMock = new Mock<ICheckDoctorWorkingTime>();
//        checkClinicWorkingTimeMock.Setup(
//                    x => x.IsValid(It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(true);

//        checkPatientMaxAppointmentPerDayMock = new Mock<ICheckPatientMaxAppointmentPerDay>();
//        checkPatientMaxAppointmentPerDayMock.Setup(
//                    x => x.IsValid(appointmentGuid, It.IsAny<DateTime>(), It.IsAny<int>())).Returns(true);

//        checkPatientAppointmentOverlapMock = new Mock<ICheckPatientAppointmentOverlap>();
//        checkPatientAppointmentOverlapMock.Setup(
//                    x => x.IsValid(patientGuid, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(true);

//        checkDoctorAppointmentOverlapLimitMock = new Mock<ICheckDoctorAppointmentOverlapLimit>();
//        checkDoctorAppointmentOverlapLimitMock.Setup(
//                    x => x.IsValid(doctorGuid, It.IsAny<DateTime>(), It.IsAny<DateTime>())).Returns(true);
//    }

    //[Fact]
    //public void ShouldCreateAppointmentWhitValidParameters()
    //{
    //    //Arrange
    //    AppointmentTime appointmentTime = AppointmentTime.CreateNew(DateTime.Now, new TimeSpan(0, 10, 0));

    //    // Act
    //    var appointment = AppointmentEntity.CreateNew(doctorId,
    //        patientId,
    //        DateTime.Now.AddDays(1),
    //        new TimeSpan(0, 10, 0),
    //         checkClinicWorkingTimeMock.Object,
    //         checkDoctorWorkingTimeMock.Object,
    //         checkPatientMaxAppointmentPerDayMock.Object,
    //         checkPatientAppointmentOverlapMock.Object,
    //         checkDoctorAppointmentOverlapLimitMock.Object);

    //    // Assert
    //    Assert.NotNull(appointment);
    //    Assert.Equal(appointmentId, appointment.Id);
    //    Assert.Equal(appointmentTime, appointment.AppointmentTime);
    //    Assert.Equal(doctorId, appointment.DoctorId);
    //    Assert.Equal(patientId, appointment.PatientId);
    //}
//}
