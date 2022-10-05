using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FM4017Library.Helpers;

public static class DateTimeHelpers
{
    /// <summary>
    /// Convert time from utc to local time
    /// </summary>
    /// <param name="utcTime"></param>
    /// <returns></returns>
    public static DateTime? UtcTime2Local(DateTime? utcTime)
    {
        if (utcTime != null)
        {
            return TimeZoneInfo.ConvertTimeFromUtc(utcTime.Value, TimeZoneInfo.Local);
        }
        else
        {
            return null;
        }
    }


}


