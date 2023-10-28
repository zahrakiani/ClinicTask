using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KarizmaClinicManagementSystem.Framework.Utility;

public static class TimeUtility
{
    public static DateTime ConvertDateTime(this DateOnly date, TimeOnly time)
    {
        var dateTime = date.ToDateTime(time);
        return dateTime;
    }
}
