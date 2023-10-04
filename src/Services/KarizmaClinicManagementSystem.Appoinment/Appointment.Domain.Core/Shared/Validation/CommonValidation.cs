using KarizmaClinicManagementSystem.Framework.ExceptionRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Shared.Validation;

public class CommonValidation
{
    public static void CheckNotNull(object objValue, ErrorCode errorCode)
    {
        if (objValue is null)
            ThrowException(errorCode);
    }

    internal static void CheckCondition(bool isTrue, ErrorCode errorCode)
    {
        if (!isTrue)
            ThrowException(errorCode); ;
    }

    private static void ThrowException(ErrorCode errorCode)
    {
        //Log Error
        throw new Exception(errorCode.Message);
    }
}
