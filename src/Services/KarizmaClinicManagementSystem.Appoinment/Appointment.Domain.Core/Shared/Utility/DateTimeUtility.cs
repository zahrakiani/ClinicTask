using Appointment.Domain.Core.AggregatesModel.AppointmentAggregate.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Domain.Core.Shared.Utility;

public static class DateTimeUtility
{
    public static List<DayOfWeek> GetDaysBetween(DayOfWeek startDay, DayOfWeek endDay)
    {
        var startIndex = (int)startDay;
        var endIndex = (int)endDay;

        List<DayOfWeek> workingDays = new();
        workingDays.Add(startDay);
        var currentindex = startIndex;
        while (currentindex != endIndex)
        {
            if (currentindex == 6)
            {
                currentindex = 0;
            }
            else
            {
                ++currentindex;
            }

            var currentday = (DayOfWeek)currentindex;
            workingDays.Add(currentday);

        }
        return workingDays;
    }

    public static bool CheckOverlapTime(this AppointmentTime firstTime,
    DateTime intendedStartTime,
    DateTime intendedEndTime)
    {
        if (firstTime.StartTime <= intendedEndTime && firstTime.EndTime >= intendedStartTime)
        {
            return true;
        }

        return false;
    }

    public static bool CheckOverlapTime(TimeOnly firstStartTime,
        TimeOnly firstEndTime,
        TimeOnly intendedStartTime,
        TimeOnly intendedEndTime)
    {
        if (firstStartTime <= intendedEndTime && firstEndTime >= intendedStartTime)
        {
            return true;
        }

        return false;
    }
}
