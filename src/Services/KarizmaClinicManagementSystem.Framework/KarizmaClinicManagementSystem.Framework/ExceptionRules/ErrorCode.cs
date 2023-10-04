using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarizmaClinicManagementSystem.Framework.ExceptionRules;

public class ErrorCode
{
    public ErrorCode()
    {
    }
    public ErrorCode(string code, string message)
    {
        Code = code;
        Message = message;
    }
    public string Code { get; private set; }
    public string Message { get; private set; }

    public static ErrorCode IsEmpty(object propery) =>
        new ErrorCode("0001", $"The {propery} can not be empty.");
    public static ErrorCode IsNull(object propery) =>
        new ErrorCode("0002", $"The {propery} can not be null.");
    public static ErrorCode StartTimeSmallerValidation =>
    new ErrorCode("0003", "Start appointment time must be less than end time");
    public static ErrorCode StartTimeValidation =>
        new ErrorCode("0004", "Start appointment time must be more than now");

    public static ErrorCode OutsideOfClinicHours =>
        new ErrorCode("0005", "The appointment time is out of clinic working hours.");

    public static ErrorCode OutsideOfDoctorHours =>
        new ErrorCode("0006", "The appointment time is out of this doctor working hours.");
    public static ErrorCode MoreThanAllowedOfPatientAppointments(int maxNumberOfPatientAppointments) =>
        new ErrorCode("0007", $"The patient should not have more than {maxNumberOfPatientAppointments} appointments in one day");
    public static ErrorCode OverlapWithDoctorAppointment =>
        new ErrorCode("0008", "The doctor's appointment has already been reserved for this time.");

    public static ErrorCode OverlapWithPatientAppointment =>
       new ErrorCode("0009", "The appointment time has overlap with another appointment of this patient.");
    public static ErrorCode DurationTimeValidation =>
    new ErrorCode("0010", "Duration appointment time must be more than zero");

}
